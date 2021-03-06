﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spellbinder.Business;
using Spellbinder.Models.Configuration;
using Spellbinder.Services.Elysium;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Spellbinder
{
    public class Startup
    {
        readonly string MyCorsConfig = "CorsSpellbinderConfig";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Config swagger
            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Email = SwaggerConfiguration.ContactUrl };

                swagger.SwaggerDoc(SwaggerConfiguration.DocName, new Info
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = SwaggerConfiguration.DocInfoVersion,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = contact
                });
            });

            // build configuration
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.{environment}.json"), optional: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddTransient<IElysiumService, ElysiumService>();
            services.AddHttpClient<IElysiumService, ElysiumService>();
            services.AddTransient<IElysiumBusiness, ElysiumBusiness>();

            services.AddCors(options =>
            {
                options.AddPolicy(MyCorsConfig,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyCorsConfig);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
