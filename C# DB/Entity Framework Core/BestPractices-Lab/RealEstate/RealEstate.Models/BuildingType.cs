using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> Properties { get; set; }
    }
}