using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class migrelkm57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionals_AdditionalOptions_AdditionalOptionsId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionals_Servants_ServantId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AfterBuyAdditionals",
                table: "AfterBuyAdditionals");

            migrationBuilder.RenameTable(
                name: "AfterBuyAdditionals",
                newName: "AfterBuyAdditionalServants");

            migrationBuilder.RenameIndex(
                name: "IX_AfterBuyAdditionals_ServantId",
                table: "AfterBuyAdditionalServants",
                newName: "IX_AfterBuyAdditionalServants_ServantId");

            migrationBuilder.RenameIndex(
                name: "IX_AfterBuyAdditionals_AdditionalOptionsId",
                table: "AfterBuyAdditionalServants",
                newName: "IX_AfterBuyAdditionalServants_AdditionalOptionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AfterBuyAdditionalServants",
                table: "AfterBuyAdditionalServants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AfterBuyAdditionalServants_AdditionalOptions_AdditionalOpti~",
                table: "AfterBuyAdditionalServants",
                column: "AdditionalOptionsId",
                principalTable: "AdditionalOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AfterBuyAdditionalServants_Servants_ServantId",
                table: "AfterBuyAdditionalServants",
                column: "ServantId",
                principalTable: "Servants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionalServants_AdditionalOptions_AdditionalOpti~",
                table: "AfterBuyAdditionalServants");

            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionalServants_Servants_ServantId",
                table: "AfterBuyAdditionalServants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AfterBuyAdditionalServants",
                table: "AfterBuyAdditionalServants");

            migrationBuilder.RenameTable(
                name: "AfterBuyAdditionalServants",
                newName: "AfterBuyAdditionals");

            migrationBuilder.RenameIndex(
                name: "IX_AfterBuyAdditionalServants_ServantId",
                table: "AfterBuyAdditionals",
                newName: "IX_AfterBuyAdditionals_ServantId");

            migrationBuilder.RenameIndex(
                name: "IX_AfterBuyAdditionalServants_AdditionalOptionsId",
                table: "AfterBuyAdditionals",
                newName: "IX_AfterBuyAdditionals_AdditionalOptionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AfterBuyAdditionals",
                table: "AfterBuyAdditionals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AfterBuyAdditionals_AdditionalOptions_AdditionalOptionsId",
                table: "AfterBuyAdditionals",
                column: "AdditionalOptionsId",
                principalTable: "AdditionalOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AfterBuyAdditionals_Servants_ServantId",
                table: "AfterBuyAdditionals",
                column: "ServantId",
                principalTable: "Servants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
