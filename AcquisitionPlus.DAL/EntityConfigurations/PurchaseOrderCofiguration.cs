using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquisitionPlus.DAL.EntityConfigurations
{
    public class PurchaseOrderCofiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrders");

            builder.HasKey(a => a.Id);

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(e => e.IdEmployee);

            builder.HasMany(i => i.Items)
                .WithOne(po => po.PurchaseOrder)
                .HasForeignKey(i => i.IdPurchaseOrder);
        }
    }
}
