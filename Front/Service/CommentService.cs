using System.Net.Http.Json;
using Front.Models;
using AutoMapper;

namespace Front.Service
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly string _commentsEndpoint = "https://localhost:7107/api/comments/commentsById";
        private readonly string _createCommentsEndpoint = "https://localhost:7107/api/comments/CreateComment";
        private readonly string _commentsEndpointWithUser = "https://localhost:7107/api/comments/GetCommentsWithUsernames";

        public CommentService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
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

        public async Task<bool> CreateCommentAsync(CreateComment comment)
        {
            var response = await _httpClient.PostAsJsonAsync(_createCommentsEndpoint, comment);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<CommentWithUser>> GetCommentsWithUserAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{_commentsEndpointWithUser}/{postId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<CommentWithUser>>();
            return new List<CommentWithUser>();
        }
    }
}
