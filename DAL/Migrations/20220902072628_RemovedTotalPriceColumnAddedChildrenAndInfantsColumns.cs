using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RemovedTotalPriceColumnAddedChildrenAndInfantsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_price",
                table: "FlightSearchFilters");

            migrationBuilder.AlterColumn<int>(
                name: "adults",
                table: "FlightSearchFilters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "children",
                table: "FlightSearchFilters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "infants",
                table: "FlightSearchFilters",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "children",
                table: "FlightSearchFilters");

            migrationBuilder.DropColumn(
                name: "infants",
                table: "FlightSearchFilters");

            migrationBuilder.AlterColumn<int>(
                name: "adults",
                table: "FlightSearchFilters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "total_price",
                table: "FlightSearchFilters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
