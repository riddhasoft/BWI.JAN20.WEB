using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class book_enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsBookEnrollmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsBookEnrollmentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsBookEnrollmentModel_BOOKS_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOKS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsBookEnrollmentModel_STUDENTS_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsBookEnrollmentModel_BookId",
                table: "StudentsBookEnrollmentModel",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsBookEnrollmentModel_StudentId",
                table: "StudentsBookEnrollmentModel",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsBookEnrollmentModel");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
