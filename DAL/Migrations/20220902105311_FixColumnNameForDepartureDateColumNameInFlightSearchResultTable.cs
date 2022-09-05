using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class FixColumnNameForDepartureDateColumNameInFlightSearchResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "FlightSearchResults",
                newName: "departure_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "departure_date",
                table: "FlightSearchResults",
                newName: "DepartureDate");
        }
    }
}
