using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RealEstate.Data;
using RealEstate.Models;
using RealEstates.Services;
using RealEstates.Services.Models;

namespace RealEstate.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstateDbContext db;

        public PropertiesService(RealEstateDbContext realEstateDbContext)
        {
            this.db = realEstateDbContext;
        }
        public void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors)
        {
            RealEstateProperty property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year < 1800 ? null : year,
                Floor = floor <= 0 ? null : floor,
                TotalNumberOfFloors = maxFloors <= 0 ? null : maxFloors
            };

            District districtEntity = this.db.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim());
            if (districtEntity == null)
            {
                districtEntity = new District { Name = district };
            }

            property.District = districtEntity;

            BuildingType buildingTypeEntity = this.db.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());
            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType { Name = buildingType };
            }
            property.BuildingType = buildingTypeEntity;

            PropertyType propertyTypeEntity = this.db.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());
            if (propertyTypeEntity == null)
            {
                propertyTypeEntity = new PropertyType { Name = propertyType };
            }
            property.PropertyType = propertyTypeEntity;

            this.db.RealEstateProperties.Add(property);
            this.db.SaveChanges();

            this.UpdateTags(property.Id);
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            List<PropertyViewModel> filtered = db.RealEstateProperties
                .Where(x => x.Year >= minYear && x.Year <= maxYear
                        && x.Size >= minSize && x.Size <= maxSize)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Price)
                .ToList();

            return filtered;
        }


        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            List<PropertyViewModel> filtered = this.db.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Price)
                .ToList();

            return filtered;
        }

        public void UpdateTags(int propertyId)
        {
            RealEstateProperty property = this.db.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);
            property.Tags.Clear();

            if (property.Year.HasValue && property.Year < 1990)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = this.GetOrCreateTag("OldBuilding")
                });
            }

            if (property.Size > 120)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = this.GetOrCreateTag("HugeApartment")
                });
            }

            if (property.Floor == property.TotalNumberOfFloors)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = this.GetOrCreateTag("LastFloor")
                });
            }

            this.db.SaveChanges();
        }

        private Tag GetOrCreateTag(string tagName)
        {
            var tag = this.db.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim());

            if (tag == null)
            {
                tag = new Tag { Name = tagName };
            }
            return tag;
        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
        {
            return x => new PropertyViewModel
            {
                District = x.District.Name,
                BuildingType = x.BuildingType.Name,
                PropertyType = x.PropertyType.Name,
                Floor = (x.Floor ?? 0) + "/" + (x.TotalNumberOfFloors ?? 0),
                Size = x.Size,
                Price = x.Price,
                Year = x.Year
            };
        }
    }
}
