using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations.FrontendDBMigrations
{
    /// <inheritdoc />
    public partial class AddingCityEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CityID",
                table: "Guests",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Cities_CityID",
                table: "Guests",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Cities_CityID",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Guests_CityID",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Guests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
