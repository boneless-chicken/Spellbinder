using Elysium.Models.Player;
using Elysium.Models.Primary;
using Elysium.Models.Spell;
using Elysium.Models.User;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Spellbinder.Models.Configuration;
using Spellbinder.Services.Exceptions;
using System;
using System.Collections.Generic;
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
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Character>(stringResponse);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new CharacterNotFound("A character was not found");
            }
            else
            {
                throw new Exception("Error while calling characters service");
            }
        }

        public async Task<CharacterInfo> GetCharacterInfo(string id)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.CharacterInfo + "/" + id;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<CharacterInfo>(responseString);
        }

        public async Task<CharacterStats> GetCharacterStats(string id)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.CharacterStats + "/" + id;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<CharacterStats>(responseString);
        }

        public async Task<CharacterSpells> GetCharacterSpells(string id)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.CharacterSpells + "/" + id;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<CharacterSpells>(responseString);
        }

        public async Task<Spell> GetSpell(string id)
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.Spell + "/" + id;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<Spell>(responseString);
        }

        public async Task<IEnumerable<Spell>> GetSpell()
        {
            var uri = _elysiumConfig.BaseAddress + _elysiumConfig.Spell;
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<IEnumerable<Spell>>(responseString);
        }
    }
}
