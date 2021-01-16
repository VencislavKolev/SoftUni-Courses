using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            //string result = GetEmployeesFullInformation(dbContext);
            //string result = GetEmployeesWithSalaryOver50000(dbContext);
            //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
            string result = AddNewAddressToEmployee(dbContext);

            Console.WriteLine(result);
        }

        //P03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName}" +
                    $"{e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //P05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development ")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DeparmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DeparmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //P06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context
                .Employees
                .First(e => e.LastName == "Nakov");
            employeeNakov.Address = newAddress;

            context.SaveChanges();

            List<string> addresses = context
                .Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
