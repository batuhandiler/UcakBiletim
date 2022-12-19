using Microsoft.EntityFrameworkCore.Migrations;

namespace UcakBiletim.DataAccess.Migrations
{
    public partial class ReservationTblRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnFlightId",
                table: "Reservations",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId",
                unique: true,
                filter: "[ReturnFlightId] IS NOT NULL");

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
                name: "FK_Reservations_Flights_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnFlightId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_ReturnFlightId",
                table: "Reservations",
                column: "ReturnFlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
