using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}