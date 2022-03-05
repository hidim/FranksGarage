using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranksGarage.Model
{
    [Table("Cars")]
    public class CarsModel
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "vehicles")]
        public List<VehiclesModel> Vehicles { get; set; } = new List<VehiclesModel>();
    }
}
