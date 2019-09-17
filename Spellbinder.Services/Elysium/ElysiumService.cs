using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Spellbinder.Models;
using Spellbinder.Models.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spellbinder.Services.Elysium
{
    public class ElysiumService : IElysiumService
    {
        private readonly HttpClient _httpClient;
        private readonly ElysiumConfig _elysiumConfig;

        public ElysiumService(HttpClient httpClient, IOptions<AppSettings> configuration)
        {
            _httpClient = httpClient;
            _elysiumConfig = configuration.Value.ElysiumConfig;
        }

        public async Task<User> GetUser(string uid)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.User + "/" + uid;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<User>(responseString);
        }

        public async Task<User> CreateUser(User user)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.User;
            var jsonInString = JsonConvert.SerializeObject(user);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseString);
        }

        public async Task<Character> GetCharacter(string id)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.Character + "/" + id;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<Character>(responseString);
        }
    }
}
