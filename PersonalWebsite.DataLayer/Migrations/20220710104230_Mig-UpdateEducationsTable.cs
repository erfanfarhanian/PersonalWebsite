using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.DataLayer.Migrations
{
    public partial class MigUpdateEducationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TillDate",
                table: "Educations",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TillDate",
                table: "Educations",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
