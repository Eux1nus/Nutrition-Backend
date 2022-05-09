using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class elgkn4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Consultations");

            migrationBuilder.AddColumn<int>(
                name: "AboutMeInfo",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlcoholDrink",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoffeeDependence",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndOfTheDayEnergy",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pressure",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegularStool",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SleepTime",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Smoking",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplySystem",
                table: "Questionnaire",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Consultations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMeInfo",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "AlcoholDrink",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CoffeeDependence",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "EndOfTheDayEnergy",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "RegularStool",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "SleepTime",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Smoking",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "SupplySystem",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Consultations");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Consultations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
