using Microsoft.EntityFrameworkCore.Migrations;

namespace UcakBiletim.DataAccess.Migrations
{
    public partial class ReservationCabinClassColAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CabinClass",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabinClass",
                table: "Reservations");
        }
    }
}
