using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.DataLayer.Migrations
{
    public partial class Mig_AddUserImageClmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "Users",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "Users");
        }
    }
}
