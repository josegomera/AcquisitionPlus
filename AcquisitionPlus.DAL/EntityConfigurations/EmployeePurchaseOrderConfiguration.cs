using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquisitionPlus.DAL.EntityConfigurations
{
    public class EmployeePurchaseOrderConfiguration : IEntityTypeConfiguration<EmployeePurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<EmployeePurchaseOrder> builder)
        {
            builder.ToTable("EmployeePurchaseOrders");

            builder.HasKey(k => new { k.IdEmployee, k.IdPurchaseOrder });

            builder.HasOne(ep => ep.Employee)
                 .WithMany(e => e.employeePurchaseOrders)
                 .HasForeignKey(ep => ep.IdEmployee);

            builder.HasOne(ep => ep.PurchaseOrder)
                 .WithMany(e => e.employeePurchaseOrders)
                 .HasForeignKey(ep => ep.IdPurchaseOrder);
        }
    }
}
