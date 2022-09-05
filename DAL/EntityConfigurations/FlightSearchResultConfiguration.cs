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
    internal class FlightSearchResultConfiguration : IEntityTypeConfiguration<FlightSearchResult>
    {
        public void Configure(EntityTypeBuilder<FlightSearchResult> builder)
        {
            builder.HasKey(k => k.Id)
                   .HasName("PK_FlightSearchResult");

            builder.Property(p => p.DepartureAirport)
                   .HasColumnName("departure_airport")
                   .HasMaxLength(5);

            builder.Property(p => p.DepartureDate)
              .HasColumnName("departure_date")
              .HasMaxLength(50);


            builder.Property(p => p.ArivalAirport)
                     .HasColumnName("arival_airport")
                     .HasMaxLength(5);

            builder.Property(p => p.ArivalDate)
                .HasColumnName("arival_date")
                .HasMaxLength(50);

            builder.Property(p => p.Currency)
                .HasColumnName("currency")
                .HasMaxLength(5);

            builder.Property(p => p.NumberOfPassengers)
                .HasColumnName("number_of_passengers");

            builder.Property(p => p.NumberOfTransfers)
                .HasColumnName("number_of_transfers");

            builder.Property(p => p.TotalPrice)
                .HasColumnName("total_price")
                .HasMaxLength(100);

            builder.Property(p => p.FlightSearchFilterId)
               .HasColumnName("flight_search_filter_id");


            builder.HasOne(fsf => fsf.FlightSearchFilter)
                    .WithMany(fsr => fsr.FlightSearchResults)
                    .HasForeignKey(fsf => fsf.FlightSearchFilterId);

        }
    }
}
