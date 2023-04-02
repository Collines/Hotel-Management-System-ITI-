using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations.FrontendDBMigrations
{
    /// <inheritdoc />
    public partial class RemovingPaymentColumnFromGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Payments_PaymentID",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_PaymentID",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "GuestID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GuestID",
                table: "Payments",
                column: "GuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Guests_GuestID",
                table: "Payments",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Guests_GuestID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_GuestID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "GuestID",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PaymentID",
                table: "Guests",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Payments_PaymentID",
                table: "Guests",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
