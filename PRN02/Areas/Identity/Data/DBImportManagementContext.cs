using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRN02.Areas.Identity.Data;
using PRN02.Models;

namespace PRN02.Areas.Identity.Data
{
    public class DBImportManagementContext : IdentityDbContext<AccountManager>
    {
        public DBImportManagementContext(DbContextOptions<DBImportManagementContext> options)
            : base(options)
        {
            
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);

            // Seed Model
            SeedCate(builder);
            SeedProduct(builder);

        }

        private void SeedCate(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category() { 
                    CategoryID = 1,
                    CategoryName = "Coffee"
                },
                 new Category()
                 {
                     CategoryID = 2,
                     CategoryName = "Beer"
                 }
            );
        }

        private void SeedProduct(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductID = 1,
                    ProductName = "Trung Nguyen",
                    Quantity = 10,
                    TotalPrice = 2000,
                    DateIn = DateTime.Now,
                    CategoryID = 1
                },
                new Product()
                {
                    ProductID = 2,
                    ProductName = "Thanh Dat",
                    Quantity = 12,
                    TotalPrice = 1800,
                    DateIn = DateTime.Now,
                    CategoryID = 1
                },
                new Product()
                {
                    ProductID = 3,
                    ProductName = "Tiger",
                    Quantity = 50,
                    TotalPrice = 6200,
                    DateIn = DateTime.Now,
                    CategoryID = 2
                }, new Product()
                {
                    ProductID = 4,
                    ProductName = "Heineken",
                    Quantity = 50,
                    TotalPrice = 7000,
                    DateIn = DateTime.Now,
                    CategoryID = 2
                }
            );
        }


        private void SeedUsers(ModelBuilder builder)
        {
            AccountManager account = new AccountManager()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",

                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",

                LockoutEnabled = false,
                PhoneNumber = "0345685122",

                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<AccountManager> pHash = new PasswordHasher<AccountManager>();
            account.PasswordHash = pHash.HashPassword(account, "Admin@123");
            account.EmailConfirmed = true;
           

            builder.Entity<AccountManager>().HasData(account);


            // seed staff
            AccountManager acc = new AccountManager()
            {
                Id = "174f7ccd-71a6-4caf-8afe-a7ed2971a88e",
                UserName = "staff@gmail.com",
                NormalizedUserName = "staff@gmail.com",

                Email = "staff@gmail.com",
                NormalizedEmail = "staff@gmail.com",

                LockoutEnabled = false,
                PhoneNumber = "0318881544",

                SecurityStamp = Guid.NewGuid().ToString(),
            };

            
            acc.PasswordHash = pHash.HashPassword(acc, "Staff@123");
            acc.EmailConfirmed = true;


            builder.Entity<AccountManager>().HasData(acc);

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    //ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole() { 
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330", 
                    Name = "Staff", 
                    //ConcurrencyStamp = "2", 
                    NormalizedName = "Staff" 
                }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {                
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "174f7ccd-71a6-4caf-8afe-a7ed2971a88e"
                }
            );
        }
    }
}
