using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWorkshop.Migrations
{
    public partial class addCityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Users");
        }
    }
}
