using Ensolvers_Challenge.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Ensolvers_Challenge.Shared.Enums;

namespace Ensolvers_Challenge.Backend.Data.Seeds
{
    public static class DataSeeder
    {
        public static void Init(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Users.Any())
            {
                SeedCategories(context);
                SeedUserAndNotes(context, userManager);
            }
        }

        public static void SeedCategories(ApplicationDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category 
                { 
                    Name = "Cat 1"
                },
                new Category
                {
                    Name = "Cat 2"
                },
                new Category
                {
                    Name = "Cat 3"
                },
                new Category
                {
                    Name = "Cat 4"
                },
                new Category
                {
                    Name = "Cat 5"
                },
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public static void SeedUserAndNotes(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            var rnd = new Random();
            var categories = context.Categories.ToList();
            var notes = new List<Note>()
            {
                new Note()
                {
                    Title = "Test Title 1",
                    Description = "Test Description 1",
                    Status = (int)NoteStatus.Active,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(1).ToList()
                },
                new Note()
                {
                    Title = "Test Title 2",
                    Description = "Test Description 2",
                    Status = (int)NoteStatus.Active,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(2).ToList()
                },
                new Note()
                {
                    Title = "Test Title 3",
                    Description = "Test Description 3",
                    Status = (int)NoteStatus.Active
                },
                new Note()
                {
                    Title = "Test Title 4",
                    Description = "Test Description 4",
                    Status = (int)NoteStatus.Active,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(3).ToList()
                },
                new Note()
                {
                    Title = "Test Title 5",
                    Description = "Test Description 5",
                    Status = (int)NoteStatus.Active
                },
                new Note()
                {
                    Title = "Test Title 6",
                    Description = "Test Description 6",
                    Status = (int)NoteStatus.Active,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(1).ToList()
                },
                new Note()
                {
                    Title = "Test Title 7",
                    Description = "Test Description 7",
                    Status = (int)NoteStatus.Archived,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(1).ToList()
                },
                new Note()
                {
                    Title = "Test Title 8",
                    Description = "Test Description 8",
                    Status = (int)NoteStatus.Archived,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(4).ToList()
                },
                new Note()
                {
                    Title = "Test Title 9",
                    Description = "Test Description 9",
                    Status = (int)NoteStatus.Archived
                },
                new Note()
                {
                    Title = "Test Title 10",
                    Description = "Test Description 10",
                    Status = (int)NoteStatus.Archived,
                    Categories = categories.OrderBy(x => rnd.Next()).Take(2).ToList()
                },
            };

            var user = new ApplicationUser
            {
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Notes = notes
            };

            userManager.CreateAsync(user, "Adm1n!").GetAwaiter().GetResult();

            context.SaveChanges();
        }
    }
}