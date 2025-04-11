using System.Net.Http.Json;
using Front.Models;

namespace Front.Service
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly string _getPostsEndpoint = "https://localhost:7107/api/posts/GetAllPosts";
        private readonly string _getPostByIdEndpoint = "https://localhost:7107/api/posts/Getpostbyid";
        private readonly string _getPostWithCommentsEndpoint = "https://localhost:7107/api/posts/reda";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>(_getPostsEndpoint);
        }

        public async Task<Post> GetPostById(int id)
        {
            var response = await _httpClient.GetAsync($"{_getPostByIdEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Post>();
            }

            return null;
        }
        public async Task<PostDto> GetPostWithCommentsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PostDto>($"{_getPostWithCommentsEndpoint}/{id}");
        }
    }
}
