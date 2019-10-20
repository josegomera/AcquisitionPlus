using AcquisitionPlus.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquisitionPlus.DAL.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(a => a.Id);

            builder.HasMany(e => e.Employees)
                   .WithOne(d => d.Department)
                   .HasForeignKey(e => e.IdDepartment);
        }
    }
}