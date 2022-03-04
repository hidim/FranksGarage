using FranksGarage.DataAPI.Data;
using FranksGarage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FranksGarage.DataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(ILogger<WarehouseController> logger, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetWarehouses")]
        public IEnumerable<VehiclesModel> Get()
        {
            if (_context == null)
                return Enumerable.Empty<VehiclesModel>();


            if (_context.WarehouseModel.Any())
            {
                // need to be inserted order by
                return _context.VehiclesModel.AsNoTracking().OrderBy(_t => _t.InsertedDate);//.Include(_t => _t.Cars).Include(_t => _t.Cars.Vehicles).OrderBy(_t=>_t.Cars.Vehicles.OrderBy(_f=>_f.InsertedDate));
            }
            else
            {
                FillWarehouse();
                return _context.VehiclesModel.AsNoTracking().OrderBy(_t => _t.InsertedDate);
            }
        }

        private void FillWarehouse()
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "App_Data\\warehouses.json");

            List<WarehouseModel> warehouseModels = JsonConvert.DeserializeObject<List<WarehouseModel>>(System.IO.File.ReadAllText(filePath).Replace("\n","").Replace("\\", "")) ?? new List<WarehouseModel>();

            if (warehouseModels is not null)
            {
                _context.WarehouseModel.AddRange(warehouseModels);
                _context.SaveChanges();
            }
        }
    }
}