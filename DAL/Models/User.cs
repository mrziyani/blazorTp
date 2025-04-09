using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation Property for Posts
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }

        // Navigation Property for Comments
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
