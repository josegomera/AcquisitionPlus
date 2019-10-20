using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquisitionPlus.DAL.EntityConfigurations
{
    public class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurement>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
        {
            builder.ToTable("UnitOfMeasurements");

            builder.HasKey(a => a.Id);

            builder.HasMany(p => p.Products)
                .WithOne(u => u.UnitOfMeasurement)
                .HasForeignKey(p => p.IdUnitOfMeasurement);
        }
    }
}
