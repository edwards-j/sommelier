using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sommelier.Models;
using Sommelier.Models.ViewModels;

namespace Sommelier.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options){ }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<FoodCategory> FoodCategory { get; set; }

        public DbSet<Variety> Variety { get; set; }

        public DbSet<Wine> Wine { get; set; }

        public DbSet<Winery> Winery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "Jonathan",
                LastName = "Edwards",
                UserName = "jonathan@edwards.com",
                NormalizedUserName = "JONATHAN@EDWARDS.COM",
                Email = "jonathan@edwards.com",
                NormalizedEmail = "JONATHAN@EDWARDS.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "edwards");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Name = "Dry White",
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Sweet White",
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "Rich White",
                },
                new Category()
                {
                    CategoryId = 4,
                    Name = "Sparkling",
                },
                new Category()
                {
                    CategoryId = 5,
                    Name = "Light Red",
                },
                new Category()
                {
                    CategoryId = 6,
                    Name = "Medium Red",
                },
                new Category()
                {
                    CategoryId = 7,
                    Name = "Bold Red",
                },
                new Category()
                {
                    CategoryId = 8,
                    Name = "Dessert",
                }
            );

            modelBuilder.Entity<Variety>().HasData(
                new Variety()
                {
                    VarietyId = 1,
                    Name = "White Table Wine",
                    CategoryId = 1
                },
                new Variety()
                {
                    VarietyId = 2,
                    Name = "Sauvignon Blanc",
                    CategoryId = 1
                },
                new Variety()
                {
                    VarietyId = 3,
                    Name = "Grüner Veltliner",
                    CategoryId = 1
                }, 
                new Variety()
                {
                    VarietyId = 4,
                    Name = "Pinot Grigio",
                    CategoryId = 1
                }, 
                new Variety()
                {
                    VarietyId = 5,
                    Name = "Albariño",
                    CategoryId = 1
                },
                new Variety()
                {
                    VarietyId = 6,
                    Name = "Gewürtzraminer",
                    CategoryId = 2
                },
                new Variety()
                {
                    VarietyId = 7,
                    Name = "Müller-Thurgau",
                    CategoryId = 2
                },
                new Variety()
                {
                    VarietyId = 8,
                    Name = "Malvasia",
                    CategoryId = 2
                }, 
                new Variety()
                {
                    VarietyId = 9,
                    Name = "Moscato",
                    CategoryId = 2
                }, 
                new Variety()
                {
                    VarietyId = 10,
                    Name = "Riesling",
                    CategoryId = 2
                },
                new Variety()
                {
                    VarietyId = 11,
                    Name = "Chardonnay",
                    CategoryId = 3
                },
                new Variety()
                {
                    VarietyId = 12,
                    Name = "Roussanne",
                    CategoryId = 3
                },
                new Variety()
                {
                    VarietyId = 13,
                    Name = "Marsanne",
                    CategoryId = 3
                },
                new Variety()
                {
                    VarietyId = 14,
                    Name = "Viognier",
                    CategoryId = 3
                },
                new Variety()
                {
                    VarietyId = 15,
                    Name = "Sparkling Wine",
                    CategoryId = 4
                },
                new Variety()
                {
                    VarietyId = 16,
                    Name = "Champagne",
                    CategoryId = 4
                },
                new Variety()
                {
                    VarietyId = 17,
                    Name = "Prosecco",
                    CategoryId = 4
                },
                new Variety()
                {
                    VarietyId = 18,
                    Name = "Cava",
                    CategoryId = 4
                },
                new Variety()
                {
                    VarietyId = 19,
                    Name = "St. Laurent",
                    CategoryId = 5
                },
                new Variety()
                {
                    VarietyId = 20,
                    Name = "Pinot Noir",
                    CategoryId = 5
                },
                new Variety()
                {
                    VarietyId = 21,
                    Name = "Zweigelt",
                    CategoryId = 5
                },
                new Variety()
                {
                    VarietyId = 22,
                    Name = "Gamay",
                    CategoryId = 5
                },
                new Variety()
                {
                    VarietyId = 23,
                    Name = "Red Table Wine",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 24,
                    Name = "Tempranillo",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 25,
                    Name = "Sangiovese",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 26,
                    Name = "Zinfandel",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 27,
                    Name = "Grenache/Garnacha",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 28,
                    Name = "Merlot",
                    CategoryId = 6
                },
                new Variety()
                {
                    VarietyId = 29,
                    Name = "Cabernet Sauvignon",
                    CategoryId = 7
                },
                new Variety()
                {
                    VarietyId = 30,
                    Name = "Mourvedre/Monastrell",
                    CategoryId = 7
                },
                new Variety()
                {
                    VarietyId = 31,
                    Name = "Aglianico",
                    CategoryId = 7
                },
                new Variety()
                {
                    VarietyId = 32,
                    Name = "Malbec",
                    CategoryId = 7
                },
                new Variety()
                {
                    VarietyId = 33,
                    Name = "Syrah/Shiraz",
                    CategoryId = 7
                },
                new Variety()
                {
                    VarietyId = 34,
                    Name = "Late Harvest",
                    CategoryId = 8
                },
                new Variety()
                {
                    VarietyId = 35,
                    Name = "Ice Wine",
                    CategoryId = 8
                },
                new Variety()
                {
                    VarietyId = 36,
                    Name = "Sherry",
                    CategoryId = 8
                },
                new Variety()
                {
                    VarietyId = 37,
                    Name = "Port",
                    CategoryId = 8
                }
            );

            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = 1,
                    Name = "Vegetables"
                },
                new Food()
                {
                    FoodId = 2,
                    Name = "Roasted Vegetables"
                },
                new Food()
                {
                    FoodId = 3,
                    Name = "Soft Cheese"
                },
                new Food()
                {
                    FoodId = 4,
                    Name = "Hard Cheese"
                },
                new Food()
                {
                    FoodId = 5,
                    Name = "Starches"
                },
                new Food()
                {
                    FoodId = 6,
                    Name = "Fish"
                },
                new Food()
                {
                    FoodId = 7,
                    Name = "Rich Fish"
                },
                new Food()
                {
                    FoodId = 8,
                    Name = "White Meat"
                },
                new Food()
                {
                    FoodId = 9,
                    Name = "Red Meat"
                },
                new Food()
                {
                    FoodId = 10,
                    Name = "Cured Meat"
                },
                new Food()
                {
                    FoodId = 11,
                    Name = "Sweets"
                }
            );

            modelBuilder.Entity<Winery>().HasData(
                new Winery()
                {
                    WineryId = 1,
                    Name = "Turley"
                },
                new Winery()
                {
                    WineryId = 2,
                    Name = "Arrington"
                }
            );

            modelBuilder.Entity<Wine>().HasData(
               new Wine()
               {
                   WineId = 1,
                   Name = "Heminway Vineyard",
                   VarietyId = 26,
                   WineryId = 1 ,
                   Year = 2015,
                   ApplicationUserId = user.Id,
                   Favorite = false,
                   Quantity = 2
               },
               new Wine()
               {
                   WineId = 2,
                   WineryId = 2,
                   Name = "Red Fox",
                   VarietyId = 23,
                   Year = 2016,
                   ApplicationUserId = user2.Id,
                   Favorite = true,
                   Quantity = 4
               }
           );
            modelBuilder.Entity<FoodCategory>().HasData(
                new FoodCategory()
                {
                    FoodCategoryId = 1,
                    FoodId = 1,
                    CategoryId = 1
                },
                new FoodCategory()
                {
                    FoodCategoryId = 2,
                    FoodId = 1,
                    CategoryId = 4
                },
                new FoodCategory()
                {
                    FoodCategoryId = 3,
                    FoodId = 2,
                    CategoryId = 1
                },
                new FoodCategory()
                {
                    FoodCategoryId = 4,
                    FoodId = 2,
                    CategoryId = 5
                },
                new FoodCategory()
                {
                    FoodCategoryId = 5,
                    FoodId = 2,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 6,
                    FoodId = 3,
                    CategoryId = 2
                },
                new FoodCategory()
                {
                    FoodCategoryId = 7,
                    FoodId = 3,
                    CategoryId = 3
                },
                new FoodCategory()
                {
                    FoodCategoryId = 8,
                    FoodId = 3,
                    CategoryId = 4
                },
                new FoodCategory()
                {
                    FoodCategoryId = 9,
                    FoodId = 3,
                    CategoryId = 8
                },
                new FoodCategory()
                {
                    FoodCategoryId = 10,
                    FoodId = 4,
                    CategoryId = 2
                }, 
                new FoodCategory()
                {
                    FoodCategoryId = 11,
                    FoodId = 4,
                    CategoryId = 4
                },
                new FoodCategory()
                {
                    FoodCategoryId = 12,
                    FoodId = 4,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 13,
                    FoodId = 4,
                    CategoryId = 7
                },
                new FoodCategory()
                {
                    FoodCategoryId = 14,
                    FoodId = 5,
                    CategoryId = 1
                },
                new FoodCategory()
                {
                    FoodCategoryId = 15,
                    FoodId = 5,
                    CategoryId = 3
                },
                new FoodCategory()
                {
                    FoodCategoryId = 16,
                    FoodId = 5,
                    CategoryId = 4
                },
                new FoodCategory()
                {
                    FoodCategoryId = 17,
                    FoodId = 5,
                    CategoryId = 5
                },
                new FoodCategory()
                {
                    FoodCategoryId = 18,
                    FoodId = 5,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 19,
                    FoodId = 5,
                    CategoryId = 7
                },
                new FoodCategory()
                {
                    FoodCategoryId = 20,
                    FoodId = 5,
                    CategoryId = 8
                },
                new FoodCategory()
                {
                    FoodCategoryId = 21,
                    FoodId = 6,
                    CategoryId = 1
                },
                new FoodCategory()
                {
                    FoodCategoryId = 22,
                    FoodId = 6,
                    CategoryId = 3
                },
                new FoodCategory()
                {
                    FoodCategoryId = 23,
                    FoodId = 6,
                    CategoryId = 4
                },
                new FoodCategory()
                {
                    FoodCategoryId = 24,
                    FoodId = 7,
                    CategoryId = 3
                },
                new FoodCategory()
                {
                    FoodCategoryId = 25,
                    FoodId = 7,
                    CategoryId = 5
                },
                new FoodCategory()
                {
                    FoodCategoryId = 26,
                    FoodId = 8,
                    CategoryId = 3
                },
                new FoodCategory()
                {
                    FoodCategoryId = 27,
                    FoodId = 8,
                    CategoryId = 5
                },
                new FoodCategory()
                {
                    FoodCategoryId = 28,
                    FoodId = 8,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 29,
                    FoodId = 9,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 30,
                    FoodId = 9,
                    CategoryId = 7
                },
                new FoodCategory()
                {
                    FoodCategoryId = 31,
                    FoodId = 10,
                    CategoryId = 2
                },
                new FoodCategory()
                {
                    FoodCategoryId = 32,
                    FoodId = 10,
                    CategoryId = 5
                },
                new FoodCategory()
                {
                    FoodCategoryId = 33,
                    FoodId = 10,
                    CategoryId = 6
                },
                new FoodCategory()
                {
                    FoodCategoryId = 34,
                    FoodId = 10,
                    CategoryId = 7
                },
                new FoodCategory()
                {
                    FoodCategoryId = 35,
                    FoodId = 10,
                    CategoryId = 8
                },
                new FoodCategory()
                {
                    FoodCategoryId = 36,
                    FoodId = 11,
                    CategoryId = 2
                },
                new FoodCategory()
                {
                    FoodCategoryId = 37,
                    FoodId = 11,
                    CategoryId = 8
                }
            );
        }

        //public DbSet<Sommelier.Models.ViewModels.FoodPairingViewModel> FoodPairingViewModel { get; set; }
    }
}
