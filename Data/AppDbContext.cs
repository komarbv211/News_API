using Data.DataSeeder;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SearchRequest> SearchRequests { get; set; }
        public DbSet<Statistics> Statistic { get; set; }
        public DbSet<UserFavoriteNews> UserFavoriteNews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>()
                .HasOne(n => n.Category)
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CategoryId);

            modelBuilder.Entity<News>()
                .HasOne(n => n.Author)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.AuthorId);


            modelBuilder.Entity<Comment>()
                .HasOne(c => c.News)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NewsId);

            modelBuilder.Entity<UserFavoriteNews>()
                .HasKey(ufn => new { ufn.UserId, ufn.NewsId });

            modelBuilder.Entity<UserFavoriteNews>()
                .HasOne(ufn => ufn.User)
                .WithMany(u => u.FavoriteNews)
                .HasForeignKey(ufn => ufn.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFavoriteNews>()
                .HasOne(ufn => ufn.News)
                .WithMany(n => n.FavoriteUsers)
                .HasForeignKey(ufn => ufn.NewsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.SeedUser();
            modelBuilder.SeedCategories();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedNews();
            modelBuilder.SeedComments();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
