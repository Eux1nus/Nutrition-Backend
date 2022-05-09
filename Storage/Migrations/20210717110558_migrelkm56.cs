using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class migrelkm56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalOptionsId",
                table: "UserAdditionalOptions",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterBuyAdditionalOptionsId",
                table: "UserAdditionalOptions");
        }
    }
}
