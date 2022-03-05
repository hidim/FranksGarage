namespace FranksGarage.Model
{
    public class VehicleProxyModel
    {
        public int Id { get; set; }
        public string VehicleMake { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public int VehicleModelYear { get; set; }
        public decimal VehiclePrice { get; set; }
        public bool VehicleIsLicensed { get; set; }
        public DateTime VehicleInsertedDate { get; set; }
        public string CarLocationName { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string WarehouseLocationLat { get; set; } = string.Empty;
        public string WarehouseLocationLong { get; set; } = string.Empty;


    }
}
