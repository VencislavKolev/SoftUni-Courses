namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ERROR_MESSAGE = "Invalid Data";
        private const string IMPORTED_DEPARTMENT = "Imported {0} with {1} cells";
        private const string IMPORTED_PRISONER = "Imported {0} {1} years old";
        private const string IMPORTED_OFFICER = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentCellDto[] jsonDepartmentCells = JsonConvert.DeserializeObject<ImportDepartmentCellDto[]>(jsonString);

            foreach (var jsonDto in jsonDepartmentCells)
            {
                if (!IsValid(jsonDto) || !jsonDto.Cells.All(IsValid))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Department department = new Department
                {
                    Name = jsonDto.Name,
                    Cells = jsonDto.Cells
                        .Select(x => new Cell
                        {
                            CellNumber = x.CellNumber,
                            HasWindow = x.HasWindow
                        }).ToArray()
                };

                context.Departments.Add(department);
                context.SaveChanges();
                sb.AppendLine(string.Format(IMPORTED_DEPARTMENT,
                    department.Name,
                    department.Cells.Count));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerMailDto[] jsonPrisonerMails = JsonConvert.DeserializeObject<ImportPrisonerMailDto[]>(jsonString);

            foreach (var jsonPrisonerMail in jsonPrisonerMails)
            {
                if (!IsValid(jsonPrisonerMail) || !jsonPrisonerMail.Mails.Any(IsValid))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                DateTime date;
                bool isValidReleaseDate = DateTime.TryParseExact(jsonPrisonerMail.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);


                Prisoner prisoner = new Prisoner
                {
                    FullName = jsonPrisonerMail.FullName,
                    Nickname = jsonPrisonerMail.Nickname,
                    Age = jsonPrisonerMail.Age,

                    IncarcerationDate = DateTime.ParseExact(jsonPrisonerMail.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = isValidReleaseDate ? (DateTime?)date : null,

                    Bail = jsonPrisonerMail.Bail,
                    CellId = jsonPrisonerMail.CellId,
                    Mails = jsonPrisonerMail.Mails
                        .Select(m => new Mail
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        }).ToArray()
                };

                context.Prisoners.Add(prisoner);
                context.SaveChanges();
                sb.AppendLine(string.Format(IMPORTED_PRISONER,
                    prisoner.FullName,
                    prisoner.Age));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportOfficerDto[] xmlOfficers = XmlConverter.Deserializer<ImportOfficerDto>(xmlString, "Officers");

            foreach (var xmlOfficer in xmlOfficers)
            {
                if (!IsValid(xmlOfficer))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = xmlOfficer.Name,
                    Salary = xmlOfficer.Money,
                    Position = Enum.Parse<Position>(xmlOfficer.Position),
                    Weapon = Enum.Parse<Weapon>(xmlOfficer.Weapon),
                    DepartmentId = xmlOfficer.DepartmentId,
                    OfficerPrisoners = xmlOfficer.Prisoners
                            .Select(op => new OfficerPrisoner { PrisonerId = op.PrisonerId })
                            .ToArray()
                };

                context.Officers.Add(officer);
                context.SaveChanges();
                sb.AppendLine(string.Format(IMPORTED_OFFICER,
                    officer.FullName,
                    officer.OfficerPrisoners.Count));
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}