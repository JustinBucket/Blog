using System;
using System.Collections.Generic;

namespace Blog.DTOs
{
    public class OutboundPostDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public ICollection<string> Paragraphs { get; set; }
        public DateTime CreationDate { get; set; }
        public string TypeString { get; set; }
        public string ImagePath { get; set; }
    }
}