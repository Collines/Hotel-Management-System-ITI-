using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations.FrontendDBMigrations
{
    /// <inheritdoc />
    public partial class AddingGuestPaymentRoomEntitiesForDBNormalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentSuite",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CardCVC",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CardExpireDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalBill",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Reservations",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "RoomFloor",
                table: "Reservations",
                newName: "GuestID");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalBill = table.Column<decimal>(type: "Money", nullable: false),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    CardType = table.Column<byte>(type: "tinyint", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CardExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardCVC = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    RoomFloor = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApartmentSuite = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_Guests_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestID",
                table: "Reservations",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomID",
                table: "Reservations",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PaymentID",
                table: "Guests",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Reservations",
                newName: "RoomNumber");

            migrationBuilder.RenameColumn(
                name: "GuestID",
                table: "Reservations",
                newName: "RoomFloor");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentSuite",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CardCVC",
                table: "Reservations",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CardExpireDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Reservations",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "CardType",
                table: "Reservations",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Reservations",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "PaymentType",
                table: "Reservations",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "RoomType",
                table: "Reservations",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBill",
                table: "Reservations",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Reservations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
