using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RealEstate.Data;
using RealEstate.Services;
using RealEstates.Services;

namespace RealEstate.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputJson = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");

            JsonProperty[] properties = JsonConvert.DeserializeObject<JsonProperty[]>(inputJson);

            var db = new RealEstateDbContext();
            IPropertiesService propertiesService = new PropertiesService(db);

            foreach (var property in properties.Where(x => x.Price > 15000))
            {
                propertiesService.Create(
                    property.District,
                    property.Size,
                    property.Year,
                    property.Price,
                    property.Type,
                    property.BuildingType,
                    property.Floor,
                    property.TotalFloors
                    );
            }
        }
    }
}
