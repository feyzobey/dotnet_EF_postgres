using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_EF_postgres.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_EF_postgres
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee>? Employees { get; set; }

        private const string CONNECTION_STRING = "Host=localhost;" +
                                                 "Port=5432;" +
                                                 "Username=postgres;" +
                                                 "Password=postgres;" +
                                                 "Database=test76";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e => e.ToTable("employees"));
            base.OnModelCreating(modelBuilder);
        }

        public List<Employee> GetAll()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.Find(id);
            }
        }

        public void DeleteAll(List<Employee> employees)
        {
            using (var db = new EmployeeContext())
            {
                db.Remove(Employees.ToList());
            }
        }
    }
}