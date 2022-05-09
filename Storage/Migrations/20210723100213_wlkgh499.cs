using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class wlkgh499 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Questionnaire");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "UserServants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSkypePayed",
                table: "UserServants",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "UserServants");

            migrationBuilder.DropColumn(
                name: "IsSkypePayed",
                table: "UserServants");

            migrationBuilder.AddColumn<double>(
                name: "BloodType",
                table: "Questionnaire",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
