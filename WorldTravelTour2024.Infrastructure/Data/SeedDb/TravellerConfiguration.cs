using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Infrastructure.Data.SeedDb
{
    public class TravellerConfiguration : IEntityTypeConfiguration<Traveller>
    {
        public void Configure(EntityTypeBuilder<Traveller> builder)
        {
            var data = new SeedDatabase();
            builder.HasData(data.Traveller);
        }
    }
}
