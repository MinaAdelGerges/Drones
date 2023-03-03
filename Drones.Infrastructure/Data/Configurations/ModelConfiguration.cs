using Drones.Domain.Entities;
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
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {

            builder.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
            builder.HasQueryFilter(x => x.IsDeleted != true);

            //SeedingData

            builder.SeedDataForModel();

        }
    }
}
