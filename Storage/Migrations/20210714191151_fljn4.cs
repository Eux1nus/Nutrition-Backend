using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class fljn4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftSertificates_Persons_PersonId",
                table: "GiftSertificates");

            migrationBuilder.DropIndex(
                name: "IX_GiftSertificates_PersonId",
                table: "GiftSertificates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "GiftSertificates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "GiftSertificates",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftSertificates_PersonId",
                table: "GiftSertificates",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftSertificates_Persons_PersonId",
                table: "GiftSertificates",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
