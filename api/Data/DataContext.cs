using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>()
                .Property(p => p.Paragraphs)
                .HasConversion(p => string.Join("|", p),
                    p => p.Split("|", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}