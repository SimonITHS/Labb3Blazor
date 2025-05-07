using Labb3Blazor.Models;
namespace Labb3Blazor.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Project>> GetProject()
        {
            var projects = await _httpClient.GetFromJsonAsync<List<Project>>("https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/projects");
            return projects ?? new List<Project>();
        }

        public async Task AddProject(Project project)
        {
            var response = await _httpClient.PostAsJsonAsync("https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/projects", project);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ Misslyckades med att lägga till ett projekt");
            }
        }

        public async Task DeleteProject(int projectId)
        {
            var response = await _httpClient.DeleteAsync($"https://labb3apidatabase-dqhfa9agc3hee2ec.westeurope-01.azurewebsites.net/projects/{projectId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ Misslyckades med att ta bort ett projekt");
            }
        }

    }


}
