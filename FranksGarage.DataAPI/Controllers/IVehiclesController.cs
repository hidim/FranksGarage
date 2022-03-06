using FranksGarage.Model;

namespace FranksGarage.DataAPI.Controllers
{
    public interface IVehiclesController
    {
        IEnumerable<VehiclesModel> Get();
        VehicleProxyModel Get(int id);
    }
}