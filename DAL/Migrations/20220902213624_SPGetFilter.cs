using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SPGetFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure =
            @"CREATE PROCEDURE [dbo].[sp_GetFilter]
            @originCode varchar(50),
			@destinationCode varchar(50),
            @departureDate varchar(50),
			@returnDate varchar(50),
			@currencyCode varchar(50),
			@adults int,
			@children int,
			@infants int

        AS

        BEGIN
            SET NOCOUNT ON;
            select * from FlightSearchFilters FSF
			where FSF.origin_location_code = @originCode
			and FSF.destination_location_code = @destinationCode
			and FSF.departure_date = @departureDate
			and FSF.return_date = @returnDate
			and FSF.currency_code = @currencyCode
			and FSF.adults = @adults
			and FSF.children = @children
			and FSF.infants = @infants
        END
        GO";
            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROCEDURE sp_GetFilter";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
