using System.Text.Json.Serialization;

namespace Front.Models
{
    public class Comment
    {
     
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key for Post
       
        
    }
}
