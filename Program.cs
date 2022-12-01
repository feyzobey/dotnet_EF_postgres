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
            var employee = new Employee
            {
                Name = "John",
                Surname = "Doe",
                Age = 25
            };
            
            context.AddAsync(employee);
        }
    }
}