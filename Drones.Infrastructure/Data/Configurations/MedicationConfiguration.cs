using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Drones.Infrastructure.Data.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.Code).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Image).HasColumnType("nvarchar(500)");

        }


    }
}
