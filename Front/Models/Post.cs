﻿using System.Text.Json.Serialization;

namespace Front.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key for User
        
    }
}
