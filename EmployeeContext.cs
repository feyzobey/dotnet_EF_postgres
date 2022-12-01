using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intro.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Intro
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee>? Employees { get; set; }

        private const string CONNECTION_STRING = "Host=localhost;" +
                                                 "Port=5432;" +
                                                 "Username=postgres;" +
                                                 "Password=postgres;" +
                                                 "Database=test76";

        public void ConfigureServices(IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<EmployeeContext>(optionsBuilder => optionsBuilder.UseNpgsql(CONNECTION_STRING));
        }
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
        public async Task Add(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (var db = new EmployeeContext())
            {
                return await db.Employees.ToListAsync();
            }
        }
        public async Task<Employee> Get(int id)
        {
            using (var db = new EmployeeContext())
            {
                return await db.Employees.FindAsync(id);
            }
        }
        public async Task Update(int id, Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Employees.Update(employee);
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = await db.Employees.FindAsync(id);
                if (employee == null)
                    return;

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
        }
    }
}