using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class ewrgln4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreementIsChecked",
                table: "Persons",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementIsChecked",
                table: "Persons");
        }
    }
}
