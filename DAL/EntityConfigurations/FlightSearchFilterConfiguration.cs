using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfigurations
{
    internal class FlightSearchFilterConfiguration : IEntityTypeConfiguration<FlightSearchFilter>
    {
        public void Configure(EntityTypeBuilder<FlightSearchFilter> builder)
        {
            builder.HasKey(k => k.Id)
                   .HasName("PK_FlightSearchFilters");

            builder.Property(p => p.Id)
                    .HasColumnName("id");

            builder.Property(p => p.OriginLocationCode)
               .HasColumnName("origin_location_code")
                .HasMaxLength(5);

            builder.Property(p => p.DestinationLocationCode)
                   .HasColumnName("destination_location_code")
                    .HasMaxLength(5);

            builder.Property(p => p.DepartureDate)
                  .HasColumnName("departure_date")
                   .HasMaxLength(50);

            builder.Property(p => p.ReturnDate)
                  .HasColumnName("return_date")
                   .HasMaxLength(50);

            builder.Property(p => p.CurrencyCode)
                    .HasColumnName("currency_code")
                     .HasMaxLength(5);

            builder.Property(p => p.Children)
                    .HasColumnName("children");

            builder.Property(p => p.Infants)
                   .HasColumnName("infants");



            builder.Property(p => p.Adults)
                    .HasColumnName("adults");
                     
        }
    }
}
