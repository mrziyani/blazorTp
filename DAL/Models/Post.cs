using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key for User
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }  // Relation: Un Post appartient à un User

        // Navigation Property for Comments
        [JsonIgnore]
        public ICollection<Comment>? Comments { get; set; }
    }
}
