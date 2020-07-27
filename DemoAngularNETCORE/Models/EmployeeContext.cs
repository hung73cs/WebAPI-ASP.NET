using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DemoAngularNETCORE.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
            {
                EmployeeId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                PhoneNumber = "999-888-7777",
                Gender = "Male"
            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                Email = "jan.kirsten@gmail.com",
                PhoneNumber = "111-222-3333",
                Gender = "Female"

            }, new Employee
            {
                EmployeeId = 3,
                FirstName = "Jenny",
                LastName = "Fish",
                Email = "jenny.fish@gmail.com",
                PhoneNumber = "444-777-3333",
                Gender = "Female"
            });
        }
    }
}
