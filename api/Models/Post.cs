using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public ICollection<string> Paragraphs { get; set; }
        public DateTime CreationDate { get; set; }
        public MediaType Type { get; set; }
        public string ImagePath { get; set; }
    }
}