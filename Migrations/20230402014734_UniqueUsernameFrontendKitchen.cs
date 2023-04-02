using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UniqueUsernameFrontendKitchen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_KitchenUsers_Username",
                table: "KitchenUsers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FrontendUsers_Username",
                table: "FrontendUsers",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KitchenUsers_Username",
                table: "KitchenUsers");

            migrationBuilder.DropIndex(
                name: "IX_FrontendUsers_Username",
                table: "FrontendUsers");
        }
    }
}
