using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreGuestAddtribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Guests",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Guests");
        }
    }
}
