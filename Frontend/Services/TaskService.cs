using Common.DTOs.Tasks;
using Common.DTOs.Users;
using System.Net.Http.Json;

namespace Frontend.Services
{
    // TODO - rename all methods to include async at the end
    public class TaskService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<TaskDTO>> GetTasks(string? searchText)
        {
            var request = "api/tasks";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                request += $"?search={searchText}";
            }

            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>(request);

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

        public async Task AssignTask(int taskId, string userId)
        {
            await _httpClient.PostAsJsonAsync(
                "api/tasks/assign",
                new AssignTaskDto 
                {
                    TaskId = taskId,
                    UserId = userId
                });
        }

        // TODO - this can be put into a seperate service?
        public async Task<List<UserDTO>> GetUsers()
        {            
            var result = await _httpClient.GetFromJsonAsync<List<UserDTO>>("api/users");

            // TODO - error handling
            return result;
        }      
    }
}
