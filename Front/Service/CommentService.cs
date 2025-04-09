using System.Net.Http.Json;
using Front.Models;

namespace Front.Service
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _commentsEndpoint = "https://localhost:7107/api/comments/commentsById";

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{_commentsEndpoint}/{postId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Comment>>();
            }
            return new List<Comment>();
        }
    }
}
