using Microsoft.EntityFrameworkCore.Migrations;

namespace LimeHome.BackEnd.Demo.Migrations
{
    public partial class updated_hotel_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelName",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "HotelId",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "HotelName",
                table: "Bookings",
                type: "text",
                nullable: true);
        }
    }
}
