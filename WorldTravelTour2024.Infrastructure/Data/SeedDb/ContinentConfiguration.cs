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
    public class ContinentConfiguration : IEntityTypeConfiguration<Continent>
    {
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            var data = new SeedDatabase();
            builder.HasData(new Continent[]
            {
                data.Europe,
                data.Africa,
                data.NorthAmerica,
                data.SouthAmerica,
                data.Asia,
                data.Australia,
                data.Antarctica
            });            
        }
    }
}
