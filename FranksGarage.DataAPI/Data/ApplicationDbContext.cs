using FranksGarage.Model;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FranksGarage.DataAPI.Data
{
    public class ApplicationDbContext : DbContext, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WarehouseModel> WarehouseModel { get; set; } = null!;
        public DbSet<VehiclesModel> VehiclesModel { get; set; } = null!;
        public DbSet<CarsModel> CarsModel { get; set; } = null!;
        public DbSet<WarehouseLocationModel>? WarehouseLocationModel { get; set; } = null!;
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

        public override void Dispose()
        {
            var connection = Database.GetDbConnection();

            base.Dispose();

            SqliteConnectionPool.ReleaseConnection(connection);

            GC.SuppressFinalize(this);
        }
    }
}
