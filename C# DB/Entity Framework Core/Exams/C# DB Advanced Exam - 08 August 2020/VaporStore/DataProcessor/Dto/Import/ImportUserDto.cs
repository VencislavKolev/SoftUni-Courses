using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+\s[A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [Required]
        public ImportCardDto[] Cards { get; set; }
    }

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string CVC { get; set; }

        //[EnumDataType(typeof(CardType))]
        //public CardType Type { get; set; }
        [Required]
        public CardType? Type { get; set; }
    }
}
