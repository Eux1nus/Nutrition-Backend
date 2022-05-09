using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class lkfsd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GiftSertificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "GiftSertificates");
        }
    }
}
