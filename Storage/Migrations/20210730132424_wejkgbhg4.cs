using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class wejkgbhg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CalendarOfEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CalendarOfEvents");
        }
    }
}
