using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranksGarage.Model
{
    [Table("Vehicles")]
    public class VehiclesModel
    {
        [Key]
        [JsonProperty(PropertyName = "_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "year_model")]
        public int ModelYear { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "licensed")]
        public bool IsLicensed { get; set; }

        [JsonProperty(PropertyName = "date_added")]
        public DateTime InsertedDate { get; set; }


    }
}
