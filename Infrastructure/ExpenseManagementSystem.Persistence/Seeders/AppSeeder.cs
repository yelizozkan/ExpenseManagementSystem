using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Seeders
{
    public static class AppSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // ExpenseStatus seed
            modelBuilder.Entity<ExpenseStatus>().HasData(
                new ExpenseStatus { Id = 1, Name = "Pending", Description = "Expense is waiting for approval" },
                new ExpenseStatus { Id = 2, Name = "Approved", Description = "Expense has been approved" },
                new ExpenseStatus { Id = 3, Name = "Rejected", Description = "Expense has been rejected" }
            );

            // AppRole seed (admin ve personel rolleri)
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = 2, Name = "Personnel", NormalizedName = "PERSONNEL" }
            );

            // AppUser seed (örnek bir admin kullanıcı)
            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser
            {
                Id = 1,
                UserName = "admin@company.com",
                NormalizedUserName = "ADMIN@COMPANY.COM",
                Email = "admin@company.com",
                NormalizedEmail = "ADMIN@COMPANY.COM",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator",
                Iban = "TR000000000000000000000000",
                DepartmentName = "Management",
                Position = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123*");


            var personnelUser = new AppUser
            {
                Id = 2,
                UserName = "personel@company.com",
                NormalizedUserName = "PERSONEL@COMPANY.COM",
                Email = "personel@company.com",
                NormalizedEmail = "PERSONEL@COMPANY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Ali",
                LastName = "Yılmaz",
                Iban = "TR111111111111111111111111",
                DepartmentName = "Muhasebe",
                Position = "Personel"
            };
            personnelUser.PasswordHash = hasher.HashPassword(personnelUser, "Personel123*");


            modelBuilder.Entity<AppUser>().HasData(adminUser, personnelUser);

            // Rol atamaları
            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long> { RoleId = 1, UserId = 1 }, // Admin
                new IdentityUserRole<long> { RoleId = 2, UserId = 2 }  // Personnel
            );

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Travel", Description = "Business travel and transportation" },
                new Category { Id = 2, Name = "Meals", Description = "Food and beverages during work" },
                new Category { Id = 3, Name = "Office Supplies", Description = "Stationery and work materials" }
            );
        }
    }
}
