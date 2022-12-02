using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intro.Entities;
namespace Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new EmployeeContext();
            var employees = new Employee[4];
            employees[0] = new Employee { Id = 1, Name = "John", Surname = "Doe", Age = 25 };
            employees[1] = new Employee { Id = 2, Name = "Jane", Surname = "Doe", Age = 23 };
            employees[2] = new Employee { Id = 3, Name = "John", Surname = "Smith", Age = 30 };
            employees[3] = new Employee { Id = 4, Name = "Jane", Surname = "Smith", Age = 28 };

            // context.AddRange(employees);
            // context.SaveChanges();
            context.Update(employees[0]);
            context.SaveChanges();
            // context.AddRange(employees);
            // context.SaveChanges();
        }
    }
}