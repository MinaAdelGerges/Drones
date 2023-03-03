using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Drones.Infrastructure.Data.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.Code).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Image).HasColumnType("nvarchar(500)");
            builder.HasQueryFilter(x => x.IsDeleted != true);
            builder.HasOne(x => x.Drone).WithMany(x => x.Medications);
            //SeedingData
            //builder.SeedDataForMedication();

        }


    }
}
