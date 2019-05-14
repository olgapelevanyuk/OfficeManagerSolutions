using Microsoft.EntityFrameworkCore;
using OfficeManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeManager.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OM.Master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Firstname = "Test",
                Lastname = "Test",
                Birthdate = DateTime.UtcNow,
                Adderss = "Test city,Test street,Test home",
                City = "Test city",
                RegistrationCity = "Test registration city",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                MobilePhone = "+375291111111",
                Nationality = "Belarus",
                PassportNumber = "112233",
                PassportSerialNumber = "AB",
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
