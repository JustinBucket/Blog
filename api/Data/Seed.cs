using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Blog.Models;
using Data;

namespace Blog.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Posts.Any())
            {
                var postData = System.IO.File.ReadAllText("Data/PostSeedData.json");

                var users = JsonSerializer.Deserialize<List<Post>>(postData);

                foreach (var i in users)
                {
                    context.Posts.Add(i);
                }

                context.SaveChanges();
            }
        }
    }
}