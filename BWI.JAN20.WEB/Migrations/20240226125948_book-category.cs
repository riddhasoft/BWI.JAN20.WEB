using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class bookcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoryId",
                table: "BOOKS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookCategoriesModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoriesModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_BookCategoryId",
                table: "BOOKS",
                column: "BookCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKS_BookCategoriesModel_BookCategoryId",
                table: "BOOKS",
                column: "BookCategoryId",
                principalTable: "BookCategoriesModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKS_BookCategoriesModel_BookCategoryId",
                table: "BOOKS");

            migrationBuilder.DropTable(
                name: "BookCategoriesModel");

            migrationBuilder.DropIndex(
                name: "IX_BOOKS_BookCategoryId",
                table: "BOOKS");

            migrationBuilder.DropColumn(
                name: "BookCategoryId",
                table: "BOOKS");
        }
    }
}
