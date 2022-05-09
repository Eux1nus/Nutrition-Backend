using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class lkgrn4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Consultations");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Consultations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Consultations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Consultations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
