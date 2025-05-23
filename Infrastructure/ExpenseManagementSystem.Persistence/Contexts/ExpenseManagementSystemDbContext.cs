﻿using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Persistence.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Contexts
{
    public class ExpenseManagementSystemDbContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public ExpenseManagementSystemDbContext(DbContextOptions<ExpenseManagementSystemDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseStatus> ExpenseStatuses { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("table");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<AppRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<long>>().ToTable("UserRoles");


            AppSeeder.Seed(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseManagementSystemDbContext).Assembly);
        }
    }
}
