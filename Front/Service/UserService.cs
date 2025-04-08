using Front.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Front.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        // The API endpoint is encapsulated inside the service.
        private readonly string _registerEndpoint = "https://localhost:7107/api/auth/register";
        private readonly string _loginEndpoint = "https://localhost:7107/api/auth/login";
        private readonly string _getUsersEndpoint = "https://localhost:7107/api/auth/users";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterUserAsync(User model)
        {
            // Post the registration model as JSON to the API.
            var response = await _httpClient.PostAsJsonAsync(_registerEndpoint, model);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginUserAsync(LoginModel model)
        {
            // The API returns a token on success
            var response = await _httpClient.PostAsJsonAsync(_loginEndpoint, model);
            if (response.IsSuccessStatusCode)
            {
                // You might define a class matching the API response structure:
                // e.g., { "Token": "..." }
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return result?.Token;
            }
            return string.Empty;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(string token)
        {
            // Create an HTTP request message with the proper Authorization header.
            var request = new HttpRequestMessage(HttpMethod.Get, _getUsersEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
            }
            return new List<User>(); // or Enumerable.Empty<UserDto>()
        }
    }
}
