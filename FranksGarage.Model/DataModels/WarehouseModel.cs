using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranksGarage.Model
{
    [Table("Warehouse")]
    public class WarehouseModel
    {
        [Key]
        [JsonProperty(PropertyName = "_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "location")]
        public WarehouseLocationModel Location { get; set; } = new WarehouseLocationModel();

        [JsonProperty(PropertyName = "cars")]
        public CarsModel Cars { get; set; } = new CarsModel();
    }
}