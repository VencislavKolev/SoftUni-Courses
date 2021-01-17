using System;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            //Problem 3
            //string result = GetEmployeesFullInformation(dbContext);

            //Problem 4
            //string result = GetEmployeesWithSalaryOver50000(dbContext);

            //Problem 5
            //string result = GetEmployeesFromResearchAndDevelopment(dbContext);

            //Problem 6
            //string result = AddNewAddressToEmployee(dbContext);

            //Problem 7
            //string result = GetEmployeesInPeriod(dbContext);

            //Problem 8
            //string result = GetAddressesByTown(dbContext);

            //Problem 9
            //string result = GetEmployee147(dbContext);

            //Problem 10
            //string result = GetDepartmentsWithMoreThan5Employees(dbContext);

            //Problem 11
            //string result = GetLatestProjects(dbContext);

            //Problem 12
            //string result = IncreaseSalaries(dbContext);

            //Problem 13
            //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);

            //Problem 14
            string result = DeleteProjectById(dbContext);

            //Problem 15
            //string result = RemoveTown(dbContext);

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

        //P07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                         ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name,
                            StartDate = ep.Project
                            .StartDate
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue ? ep.Project
                            .EndDate
                            .Value
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                        }).ToList()
                }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Project)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //P08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    Address = a.AddressText,
                    Town = a.Town.Name,
                    Employees = a.Employees.Count
                })
                .OrderByDescending(x => x.Employees)
                .ThenBy(x => x.Town)
                .ThenBy(x => x.Address)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.Address}, {a.Town} - {a.Employees} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //P09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(pn => pn)
                        .ToList()
                })
                .Single();


            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var projectName in employee147.Projects)
            {
                sb.AppendLine(projectName);
            }
            return sb.ToString().TrimEnd();
        }

        //P10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.
                Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var e in department.Employees)
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //P11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in latestProjects)
            {
                sb.AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //P12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employeesToIncrease = context
                .Employees
                .Where(d => new string[]
                    {
                        "Marketing", "Engineering",
                        "Information Services", "Tool Design"
                    }
                    .Contains(d.Department.Name));

            foreach (Employee employee in employeesToIncrease)
            {
                employee.Salary += employee.Salary * 0.12m;
            }
            context.SaveChanges();

            var employees = employeesToIncrease
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        //P13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //P14
        public static string DeleteProjectById(SoftUniContext context)
        {
            Project projectId2 = context.Projects.First(p => p.ProjectId == 2);

            IQueryable<EmployeeProject> employeesWithProjectId2 = context
                .EmployeesProjects
                .Where(p => p.ProjectId == projectId2.ProjectId);

            foreach (var ep in employeesWithProjectId2)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(projectId2);
            context.SaveChanges();

            List<string> tenProjects = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            return string.Join(Environment.NewLine, tenProjects);
        }

        //P15
        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDelete = context.Towns.First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            IQueryable<Employee> employeesInTown = context.Employees
                .Where(e => addressesToDelete
                    .Any(a => a.AddressId == e.AddressId));

            foreach (var e in employeesInTown)
            {
                e.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressesCount} addresses in {townToDelete.Name} were deleted";
        }
    }
}
