using System.ComponentModel;

namespace Blog.Models
{
    public enum MediaType
    {
        Music,
        [Description("Video Game")]
        VideoGame,
        Movie,
        Book
    }
}
