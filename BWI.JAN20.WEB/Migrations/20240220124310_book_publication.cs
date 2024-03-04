using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class book_publication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Publication",
                table: "BOOKS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publication",
                table: "BOOKS");
        }
    }
}
