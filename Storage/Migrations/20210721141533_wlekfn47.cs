using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class wlekfn47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FoodDiaries");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FoodDiaries");

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChronicDiseases",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsultationPurpose",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DailyDiet",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diabetes",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DietarySupplements",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealsPerDay",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkinManifestations",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SportActivities",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TonguePlaque",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "FoodDiaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brunch",
                table: "FoodDiaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "FoodDiaries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "FoodDiaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "ChronicDiseases",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "ConsultationPurpose",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "DailyDiet",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Diabetes",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "DietarySupplements",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "MealsPerDay",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "SkinManifestations",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "SportActivities",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "TonguePlaque",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "FoodDiaries");

            migrationBuilder.DropColumn(
                name: "Brunch",
                table: "FoodDiaries");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "FoodDiaries");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "FoodDiaries");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodDiaries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FoodDiaries",
                type: "text",
                nullable: true);
        }
    }
}
