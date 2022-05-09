using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class wlefn43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarOfEvents_User_UserId",
                table: "CalendarOfEvents");

            migrationBuilder.DropIndex(
                name: "IX_CalendarOfEvents_UserId",
                table: "CalendarOfEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CalendarOfEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CalendarOfEvents");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "CalendarOfEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEnd",
                table: "CalendarOfEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "CalendarOfEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CalendarOfEvents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "CalendarOfEvents");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "CalendarOfEvents");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "CalendarOfEvents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CalendarOfEvents");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CalendarOfEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CalendarOfEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarOfEvents_UserId",
                table: "CalendarOfEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarOfEvents_User_UserId",
                table: "CalendarOfEvents",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
