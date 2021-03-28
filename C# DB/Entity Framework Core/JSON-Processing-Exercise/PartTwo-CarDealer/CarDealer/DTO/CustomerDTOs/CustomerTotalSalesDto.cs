using Newtonsoft.Json;

namespace CarDealer.DTO.CustomerDTOs
{
    public class CustomerTotalSalesDto
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpendMoney { get; set; }
    }
}
