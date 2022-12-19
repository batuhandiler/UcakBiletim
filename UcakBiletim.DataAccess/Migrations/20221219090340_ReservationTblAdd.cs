using Microsoft.EntityFrameworkCore.Migrations;

namespace UcakBiletim.DataAccess.Migrations
{
    public partial class ReservationTblAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DepartureFlightId = table.Column<int>(nullable: false),
                    ReturnFlightId = table.Column<int>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    PassengerSurname = table.Column<string>(nullable: true),
                    PassengerEmail = table.Column<string>(nullable: true),
                    CreditCardHolderName = table.Column<string>(nullable: true),
                    CreditCardNo = table.Column<string>(nullable: true),
                    CreditCardCvc = table.Column<string>(nullable: true),
                    CreditCardExpirationDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
