using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class changeSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SettingLogo",
                table: "Settings",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SettingPhoneNumber",
                table: "Settings",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingLogo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SettingPhoneNumber",
                table: "Settings");
        }
    }
}
