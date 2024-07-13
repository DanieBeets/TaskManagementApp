using Common.DTOs.Tasks;
using System.Net.Http.Json;

namespace Frontend.Services
{        
    public class TaskService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<TaskDTO>> GetTasks()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>("api/tasks");

            // TODO - error handling
            return result;
        }

        public async Task<TaskDTO> GetTask(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDTO>($"api/tasks/{id}");

            // TODO - error handling
            return result;
        }

        public async Task CreateTask(CreateTaskDTO ct)
        {
            await _httpClient.PostAsJsonAsync("api/tasks", ct);
        }

        public async Task UpdateTask(int id, UpdateTaskDTO ut)
        {
            await _httpClient.PutAsJsonAsync($"api/tasks/{id}", ut);
        }

        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"api/tasks/{id}");
        }
    }

}
