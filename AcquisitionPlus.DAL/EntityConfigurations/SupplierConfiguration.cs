using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcquisitionPlus.DAL.EntityConfigurations
{
    class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(a => a.Id);

            builder.HasMany(p => p.Products)
                   .WithOne(s => s.Supplier)
                   .HasForeignKey(p => p.IdSupplier);
        }
    }
}
