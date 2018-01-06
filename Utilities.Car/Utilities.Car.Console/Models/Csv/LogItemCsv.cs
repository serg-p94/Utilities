using Newtonsoft.Json;

namespace Utilities.Car.Console.Models.Csv
{
    public class LogItemCsv
    {
        [JsonProperty("Data")]
        public string Date { get; set; }

        [JsonProperty("Odo (km)")]
        public string Odo { get; set; }

        [JsonProperty("Fuel (litres)")]
        public string Fuel { get; set; }

        [JsonProperty("Full")]
        public string Full { get; set; }

        [JsonProperty("Price (optional)")]
        public string Price { get; set; }

        [JsonProperty("l/100km (optional)")]
        public string Consumption { get; set; }

        [JsonProperty("latitude (optional)")]
        public string Latitude { get; set; }

        [JsonProperty("longitude (optional)")]
        public string Longitude { get; set; }

        [JsonProperty("City (optional)")]
        public string City { get; set; }

        [JsonProperty("Notes (optional)")]
        public string Notes { get; set; }

        [JsonProperty("Missed")]
        public string Missed { get; set; }

        [JsonProperty("TankNumber")]
        public string TankNumber { get; set; }

        [JsonProperty("FuelType")]
        public string FuelType { get; set; }

        [JsonProperty("VolumePrice")]
        public string VolumePrice { get; set; }

        [JsonProperty("StationID (optional)")]
        public string StationID { get; set; }

        [JsonProperty("ExcludeDistance")]
        public string ExcludeDistance { get; set; }

        [JsonProperty("UniqueId")]
        public string UniqueId { get; set; }
    }
}
