using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWI.JAN20.WEB.Migrations
{
    public partial class CHANGE_EMAIL_NAME_TYPE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "STUDENTS",
                newName: "EMAIL");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "STUDENTS",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "STUDENTS",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "STUDENTS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150);
        }
    }
}
