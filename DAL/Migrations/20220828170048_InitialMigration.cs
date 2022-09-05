using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightSearchFilters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origin_location_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    destination_location_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    departure_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    return_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    currency_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSearchFilters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FlightSearchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departure_airport = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    arival_airport = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    arival_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    currency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    number_of_passengers = table.Column<byte>(type: "tinyint", nullable: false),
                    number_of_transfers = table.Column<byte>(type: "tinyint", nullable: false),
                    total_price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flight_search_filter_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSearchResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSearchResults_FlightSearchFilters_flight_search_filter_id",
                        column: x => x.flight_search_filter_id,
                        principalTable: "FlightSearchFilters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightSearchResults_flight_search_filter_id",
                table: "FlightSearchResults",
                column: "flight_search_filter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightSearchResults");

            migrationBuilder.DropTable(
                name: "FlightSearchFilters");
        }
    }
}
