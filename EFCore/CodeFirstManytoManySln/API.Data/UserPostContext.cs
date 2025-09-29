using API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace API.Data
{
    public class UserPostContext :DbContext
    {
        public UserPostContext(DbContextOptions<UserPostContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserPost> UserPosts { get; set; } 
        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("data source=VIJIT_SHETTY;database=APITWO;integrated security=true;trustservercertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u=>
            {                 u.HasKey(x => x.UserId);
                u.Property(x => x.Username).IsRequired().HasMaxLength(50);
                u.HasIndex(x => x.Email).IsUnique();
            });
            modelBuilder.Entity<Post>(p =>
            {
                p.HasKey(x => x.PostId);
                p.Property(x => x.Title).IsRequired().HasMaxLength(100);
                p.Property(x => x.Content).IsRequired().HasMaxLength(400);
            });
            modelBuilder.Entity<UserPost>(
               up =>
               {
                   up.HasKey(x => new { x.UserId, x.PostId });
                   up.HasOne(u => u.User)
                   .WithMany(up => up.UserPosts)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
                   up.HasOne(p => p.Post)
                   .WithMany(up => up.UserPosts)
                   .HasForeignKey(p => p.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
                   up.Property(x=>x.IsAuthor).HasDefaultValue(false);
               });
           
        }
    }
}
