using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class CHANGE_BOOKMODEL_NAME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.RenameTable(
                name: "BookModel",
                newName: "BOOKS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BOOKS",
                table: "BOOKS",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BOOKS",
                table: "BOOKS");

            migrationBuilder.RenameTable(
                name: "BOOKS",
                newName: "BookModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "Id");
        }
    }
}
