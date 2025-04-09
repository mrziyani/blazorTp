using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key for Post
        public int PostId { get; set; }
        [JsonIgnore]
        public Post? Post { get; set; }  // Relation: Un Comment appartient à un Post

        // Foreign Key for User
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }  // Relation: Un Comment appartient à un User
    }
}
