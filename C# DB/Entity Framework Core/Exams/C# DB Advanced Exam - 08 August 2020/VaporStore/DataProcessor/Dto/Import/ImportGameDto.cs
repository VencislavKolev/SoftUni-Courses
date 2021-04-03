using System;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0, (double)Decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
        //public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string[] Tags { get; set; }
    }
}
