using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataSeeder
{
    public static class DataSeederExtensions
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "14142855-e262-4715-9295-7171f80e794f",
                    UserName = "testuser",
                    NormalizedUserName = "TESTUSER",
                    Email = "testuser@example.com",
                    NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    CreatedDate = DateTime.UtcNow,
                    LastLoginDate = DateTime.UtcNow,
                    Birthdate = new DateTime(1990, 1, 1),
                    Role = "User"
                }
            );
        }
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Політика" },
                new Category { Id = 2, Name = "Спорт" },
                new Category { Id = 3, Name = "Культура" }
            );
        }

        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "Іван Іванов", UserId = "14142855-e262-4715-9295-7171f80e794f", Pseudonym = "І. І." },
                new Author { Id = 2, FullName = "Петро Петров", UserId = "14142855-e262-4715-9295-7171f80e794f", Pseudonym = "П. П." },
                new Author { Id = 3, FullName = "Марія Петровa", UserId = "14142855-e262-4715-9295-7171f80e794f", Pseudonym = "М. М." }
            );
        }

        public static void SeedNews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(
                new News { Id = 1, Title = "Новина 1", Description = "Опис новини 1", FullText = "Текст новини 1", PublishDate = DateTime.Now, CategoryId = 1, AuthorId = 1 },
                new News { Id = 2, Title = "Новина 2", Description = "Опис новини 2", FullText = "Текст новини 2", PublishDate = DateTime.Now, CategoryId = 2, AuthorId = 2 },
                new News { Id = 3, Title = "Новина 3", Description = "Опис новини 3", FullText = "Текст новини 3", PublishDate = DateTime.Now, CategoryId = 3, AuthorId = 3 }
            );
        }

        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment(1, "14142855-e262-4715-9295-7171f80e794f", "This is a comment.") { Id = 1, DatePosted = DateTime.Now },
                new Comment(1, "14142855-e262-4715-9295-7171f80e794f", "Another comment.") { Id = 2, DatePosted = DateTime.Now },
                new Comment(2, "14142855-e262-4715-9295-7171f80e794f", "More comments.") { Id = 3, DatePosted = DateTime.Now }
            );

        }
        
    }
}
