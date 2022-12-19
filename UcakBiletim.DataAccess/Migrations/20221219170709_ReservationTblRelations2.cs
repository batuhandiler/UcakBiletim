using Microsoft.EntityFrameworkCore.Migrations;

namespace UcakBiletim.DataAccess.Migrations
{
    public partial class ReservationTblRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId",
                unique: true,
                filter: "[ReturnFlightId] IS NOT NULL");
        }
    }
}
