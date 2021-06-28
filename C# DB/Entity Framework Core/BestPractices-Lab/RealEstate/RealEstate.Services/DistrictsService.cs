using RealEstate.Data;
using RealEstate.Models;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly RealEstateDbContext db;

        public DistrictsService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10)
        {
            return this.db.Districts
                .OrderByDescending(x => x.Properties.Average(x => x.Price))
                .Select(MapToDistrictViewModel())
                .Take(count)
                .ToList();
        }


        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            return this.db.Districts
               .OrderByDescending(x => x.Properties.Count())
               .Select(MapToDistrictViewModel())
               .Take(count)
               .ToList();
        }

        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return x => new DistrictViewModel
            {
                Name = x.Name,
                PropertiesCount = x.Properties.Count(),
                MinPrice = x.Properties.Min(x => x.Price),
                MaxPrice = x.Properties.Max(x => x.Price),
                AveragePrice = x.Properties.Average(x => x.Price)
            };
        }
    }
}
