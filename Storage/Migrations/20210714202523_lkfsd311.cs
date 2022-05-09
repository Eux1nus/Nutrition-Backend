using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class lkfsd311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "GiftSertificates");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserGiftSertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserGiftSertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserGiftSertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserGiftSertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "UserGiftSertificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserGiftSertificates");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserGiftSertificates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserGiftSertificates");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserGiftSertificates");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "UserGiftSertificates");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GiftSertificates",
                type: "text",
                nullable: true);
        }
    }
}
