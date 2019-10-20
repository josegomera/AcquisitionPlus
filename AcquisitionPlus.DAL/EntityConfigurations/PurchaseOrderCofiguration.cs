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

            builder.HasMany(p => p.Products)
                .WithOne(po => po.PurchaseOrder)
                .HasForeignKey(p => p.IdPurchaseOrder);
        }
    }
}
