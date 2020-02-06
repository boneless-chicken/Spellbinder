using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spellbinder.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Spellbinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> TransactionStatus(TransactionMessage message)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(message);
                SmtpClient client;
                using (client = new SmtpClient("smtp.office365.com", 587))
                {
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Timeout = 60;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential("diego.lovera@bestday.com", "T3mporal1");

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("diego.lovera@bestday.com")
                    };
                    mailMessage.To.Add("diego.lovera@bestday.com");
                    mailMessage.Body = jsonData;
                    mailMessage.Subject = "Mensaje de transacción";
                    await client.SendMailAsync(mailMessage);
                };
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}