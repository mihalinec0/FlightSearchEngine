﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(FlightSearchEngineDbContext))]
    partial class FlightSearchEngineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.FlightSearchFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Adults")
                        .HasColumnType("int")
                        .HasColumnName("adults");

                    b.Property<int?>("Children")
                        .HasColumnType("int")
                        .HasColumnName("children");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("currency_code");

                    b.Property<string>("DepartureDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("departure_date");

                    b.Property<string>("DestinationLocationCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("destination_location_code");

                    b.Property<int?>("Infants")
                        .HasColumnType("int")
                        .HasColumnName("infants");

                    b.Property<string>("OriginLocationCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("origin_location_code");

                    b.Property<string>("ReturnDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("return_date");

                    b.HasKey("Id")
                        .HasName("PK_FlightSearchFilters");

                    b.ToTable("FlightSearchFilters");
                });

            modelBuilder.Entity("DAL.Models.FlightSearchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArivalAirport")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("arival_airport");

                    b.Property<DateTime?>("ArivalDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("arival_date");

                    b.Property<string>("Currency")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("currency");

                    b.Property<string>("DepartureAirport")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("departure_airport");

                    b.Property<DateTime?>("DepartureDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("departure_date");

                    b.Property<int>("FlightSearchFilterId")
                        .HasColumnType("int")
                        .HasColumnName("flight_search_filter_id");

                    b.Property<int>("NumberOfPassengers")
                        .HasColumnType("int")
                        .HasColumnName("number_of_passengers");

                    b.Property<int>("NumberOfTransfers")
                        .HasColumnType("int")
                        .HasColumnName("number_of_transfers");

                    b.Property<string>("TotalPrice")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("total_price");

                    b.HasKey("Id")
                        .HasName("PK_FlightSearchResult");

                    b.HasIndex("FlightSearchFilterId");

                    b.ToTable("FlightSearchResults");
                });

            modelBuilder.Entity("DAL.Models.FlightSearchResult", b =>
                {
                    b.HasOne("DAL.Models.FlightSearchFilter", "FlightSearchFilter")
                        .WithMany("FlightSearchResults")
                        .HasForeignKey("FlightSearchFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightSearchFilter");
                });

            modelBuilder.Entity("DAL.Models.FlightSearchFilter", b =>
                {
                    b.Navigation("FlightSearchResults");
                });
#pragma warning restore 612, 618
        }
    }
}
