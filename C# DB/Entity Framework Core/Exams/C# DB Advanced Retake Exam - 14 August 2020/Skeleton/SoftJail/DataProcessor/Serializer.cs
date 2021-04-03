namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .ToArray()
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Where(po => po.PrisonerId == p.Id)
                        .Select(o => new
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(x => x.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers
                        .Select(x => x.Officer.Salary)
                        .Sum()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            string json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] splittedName = prisonersNames.Split(",").ToArray();

            ExportPrisonerInboxDto[] prisonersInbox = context.Prisoners
                .Where(x => splittedName.Contains(x.FullName))
                .ToArray()
                .Select(p => new ExportPrisonerInboxDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportMailDto
                        {
                            Description = string.Join("", m.Description.Reverse())
                        }).ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            string xml = XmlConverter.Serialize<ExportPrisonerInboxDto[]>(prisonersInbox, "Prisoners");

            return xml;
        }
    }
}