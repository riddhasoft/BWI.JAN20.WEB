using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class image_url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "USERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "USERS");
        }
    }
}
