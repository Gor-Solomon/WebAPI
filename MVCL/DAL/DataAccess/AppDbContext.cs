using Microsoft.EntityFrameworkCore;
using MVCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.DAL.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Employee> employees = new List<Employee>()
            {
                 new Employee
                 {
                    Id = 1 ,
                    Name = "Goruen Soghomonian" ,
                    Department = DepartmentEnumType.IT,
                    Email = "mark@pragimtech.com"
                 },
                 new Employee
                 {
                    Id = 2 ,
                    Name = "Mark Zekusberg",
                    Department = DepartmentEnumType.HR,
                    Email = "Gor@Solomon.com"
                 },
                 new Employee
                 {
                    Id = 3 ,
                    Name = "Rober Denderian",
                    Department = DepartmentEnumType.Finances,
                    Email = "Denderian@gmail.com"
                 }
            };

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
