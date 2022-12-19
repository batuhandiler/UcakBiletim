using Microsoft.EntityFrameworkCore.Migrations;

namespace UcakBiletim.DataAccess.Migrations
{
    public partial class ReservationTblRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DepartureFlightId",
                table: "Reservations",
                column: "DepartureFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_DepartureFlightId",
                table: "Reservations",
                column: "DepartureFlightId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_DepartureFlightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DepartureFlightId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations");
        }
    }
}
