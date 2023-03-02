using Drones.Domain.Entities;
using Drones.Domain.Enums;
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
            builder.HasKey(x => x.SerialNumber);
            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.State).HasDefaultValue(DronesStateEnum.IDLE).IsRequired(); ;
            builder.Property(x => x.BatteryCapacity).IsRequired();
            builder.Property(x => x.Model).HasDefaultValue(DroneModelEnum.LightWeight).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(500);

        }


    }
}
