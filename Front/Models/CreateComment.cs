using System.Text.Json.Serialization;

namespace Front.Models
{
    public class CreateComment
    {
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }

            public int PostId { get; set; }
    
            public int UserId { get; set; }
    }
}
