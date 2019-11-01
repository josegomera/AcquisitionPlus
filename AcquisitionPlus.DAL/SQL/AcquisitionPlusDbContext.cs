using AcquisitionPlus.DAL.EntityConfigurations;
using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionPlus.DAL.SQL
{
    public partial class AcquisitionPlusDbContext : DbContext
    {
        public AcquisitionPlusDbContext(DbContextOptions<AcquisitionPlusDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new PurchaseOrderCofiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new UnitOfMeasurementConfiguration());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    }
}
