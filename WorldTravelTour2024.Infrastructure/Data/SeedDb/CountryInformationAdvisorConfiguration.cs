using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Infrastructure.Data.SeedDb
{
    public class CountryInformationAdvisorConfiguration : IEntityTypeConfiguration<CountryInformationAdvisor>
    {
        public void Configure(EntityTypeBuilder<CountryInformationAdvisor> builder)
        {
            var data = new SeedDatabase();
            builder.HasData(new CountryInformationAdvisor[] { data.CountryInformationAdvisor });
        }
    }
}
