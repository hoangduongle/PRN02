using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRN02.Areas.Identity.Data;

namespace PRN02.Areas.Identity.Data
{
    public class DBImportManagementContext : IdentityDbContext<AccountManager>
    {
        public DBImportManagementContext(DbContextOptions<DBImportManagementContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);

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
                }
            );
        }
    }
}
