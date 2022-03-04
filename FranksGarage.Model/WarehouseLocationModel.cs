using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranksGarage.Model
{
    [Table("WarehouseLocation")]
    public class WarehouseLocationModel
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string latitude { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "long")]
        public string longitude { get; set; } = string.Empty;
    }
}
