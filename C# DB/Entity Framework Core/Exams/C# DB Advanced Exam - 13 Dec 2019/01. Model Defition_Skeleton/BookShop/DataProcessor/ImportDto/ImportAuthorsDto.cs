using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})-(\d{3})-(\d{4})$")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ImportAuthorsBooksDto[] Books { get; set; }
    }

    public class ImportAuthorsBooksDto
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}
