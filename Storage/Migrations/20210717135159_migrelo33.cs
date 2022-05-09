using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class migrelo33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterBuyAdditionalOptionsId",
                table: "UserAdditionalOptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalOptionsId",
                table: "UserAdditionalOptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
