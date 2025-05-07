using Labb3Blazor.Models;
using System.Net.Http.Json;

namespace Labb3Blazor.Services
{
    public class SkillService
    {
        private readonly HttpClient _httpClient;

        public SkillService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Skill>> GetSkill()
        {
            var skills = await _httpClient.GetFromJsonAsync<List<Skill>>("https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/skills");
            return skills ?? new List<Skill>();
        }

        public async Task AddSkill(Skill skill)
        {
            var response = await _httpClient.PostAsJsonAsync("https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/skills", skill);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ Misslyckades med att lägga till en skill");
            }
        }

        public async Task DeleteSkill(int skillId)
        {
            var response = await _httpClient.DeleteAsync($"https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/skills/{skillId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ Misslyckades med att ta bort en skill");
            }
        }
    }
}
