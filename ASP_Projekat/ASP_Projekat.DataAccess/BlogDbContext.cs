using ASP_Projekat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace ASP_Projekat.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {

        }
        public BlogDbContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress01;Initial Catalog=ASP_Projekat_Blog;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Comment>().Property(x => x.CommentedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<BlogImage>().HasKey(x => new { x.BlogId, x.ImageId });
            modelBuilder.Entity<BlogReaction>().HasKey(x => new { x.ReactionId, x.BlogId, x.UserId });
            modelBuilder.Entity<BlogTag>().HasKey(x => new { x.BlogId, x.TagId });
            modelBuilder.Entity<RoleUseCases>().HasKey(x => new { x.RoleId, x.UseacaseId });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<BlogReaction> BlogReactions { get; set; }


    }
}