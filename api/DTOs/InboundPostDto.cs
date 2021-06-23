using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Blog.DTOs
{
    public class InboundPostDto
    {
        public string Title { get; set; }
        public ICollection<string> Paragraphs { get; set; }
        public string MediaTypeString { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}