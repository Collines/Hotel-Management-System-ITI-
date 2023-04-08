using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations.FrontendDBMigrations
{
    /// <inheritdoc />
    public partial class UpdatingPaymentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalBill",
                table: "Payments",
                newName: "Tax");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBill",
                table: "Payments",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Foodbill",
                table: "Payments",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBill",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Foodbill",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "Payments",
                newName: "TotalBill");
        }
    }
}
