using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Data.Configurations
{
    public class DroneConfiguration : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.StateId).HasDefaultValue(DronesStateEnum.IDLE).IsRequired(); ;
            builder.Property(x => x.BatteryCapacity).IsRequired();
            builder.Property(x => x.ModelId).HasDefaultValue(DroneModelEnum.LightWeight).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(500);
            builder.HasQueryFilter(x => x.IsDeleted != true);
            builder.HasOne(x => x.State);
            builder.HasOne(x => x.Model);
            builder.HasMany(x => x.Medications).WithOne(x => x.Drone);


            //10 drones

            //SeedingData
            builder.SeedDataForDrone();

        }



    }
}
