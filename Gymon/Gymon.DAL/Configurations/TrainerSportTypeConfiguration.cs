using Gymon.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations
{
    public class TrainerSportTypeConfiguration : IEntityTypeConfiguration<TrainerSportType>
    {
        public void Configure(EntityTypeBuilder<TrainerSportType> builder)
        {
            builder.HasKey(ts => new { ts.TrainerId, ts.SportTypeId });
        }
    }
}
