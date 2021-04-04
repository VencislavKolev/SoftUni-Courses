namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProjectDto[] xmlProjects = XmlConverter.Deserializer<ImportProjectDto>(xmlString, "Projects");

            foreach (var xmlProject in xmlProjects)
            {
                if (!IsValid(xmlProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                bool isValidOpenDate = DateTime.TryParseExact(xmlProject.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out projectOpenDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectDueDate;
                bool isValidDueDate = DateTime.TryParseExact(xmlProject.DueDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out projectDueDate);


                DateTime? finalProjectDueDate = isValidDueDate
                    ? (DateTime?)projectDueDate
                    : null;

                List<Task> validTasks = new List<Task>();

                foreach (var taskDto in xmlProject.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isValidTaskOpenDate = DateTime.TryParseExact(taskDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskOpenDate);

                    if (!isValidTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isValidTaskDueDate = DateTime.TryParseExact(taskDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskDueDate);

                    if (!isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (finalProjectDueDate != null)
                    {
                        if (taskDueDate > finalProjectDueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType),
                    };

                    validTasks.Add(task);
                }

                Project project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = isValidDueDate ? (DateTime?)projectDueDate : null,
                    Tasks = validTasks
                };

                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedProject,
                    project.Name,
                    project.Tasks.Count));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDto[] jsonEmployees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var jsonDto in jsonEmployees)
            {
                if (!IsValid(jsonDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = jsonDto.Username,
                    Email = jsonDto.Email,
                    Phone = jsonDto.Phone
                };

                foreach (var uniqueTask in jsonDto.Tasks.Distinct())
                {
                    if (!context.Tasks.Any(x => x.Id == uniqueTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        TaskId = uniqueTask
                    });
                }

                context.Employees.Add(employee);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count()));
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}