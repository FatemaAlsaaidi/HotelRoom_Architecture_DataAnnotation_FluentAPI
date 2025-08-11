using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class PutNationIDASIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Guests_NationalID",
                table: "Guests",
                column: "NationalID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Guests_NationalID",
                table: "Guests");
        }
    }
}
