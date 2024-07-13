using System.Net.Http.Json;

namespace Frontend.Services
{    
    public class AuthenticationService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return result?.Token ?? throw new Exception("Could not get authentication token");
        }

        public async Task Register(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerModel);
            response.EnsureSuccessStatusCode();
        }
    }

    public class AuthResponse
    {
        public required string Token { get; set; }
    }

    public class LoginModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }

    public class RegisterModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
