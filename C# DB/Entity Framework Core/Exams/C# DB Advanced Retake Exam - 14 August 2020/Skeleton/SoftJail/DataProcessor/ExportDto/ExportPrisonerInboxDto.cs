using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonerInboxDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportMailDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class ExportMailDto
    {
        public string Description { get; set; }
    }
}
