using System.Net.Http.Json;
using Common.DTOs.Authentication;

namespace Frontend.Services
{    
    public class AuthenticationService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> SignIn(SignInDTO sd)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/signin", sd);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return result?.Token ?? throw new Exception("Could not get authentication token");
        }

        public async Task Register(RegisterDTO rd)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", rd);
            response.EnsureSuccessStatusCode();
        }
    }

    public class AuthResponse
    {
        public required string Token { get; set; }
    }   
}
