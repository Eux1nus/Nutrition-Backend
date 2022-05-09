using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class migrelkm5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalOptionsServants_AfterBuyAdditionals_AfterBuyAddit~",
                table: "AdditionalOptionsServants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalOptions_AfterBuyAdditionals_AfterBuyAdditiona~",
                table: "UserAdditionalOptions");

            migrationBuilder.DropIndex(
                name: "IX_UserAdditionalOptions_AfterBuyAdditionalId",
                table: "UserAdditionalOptions");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalOptionsServants_AfterBuyAdditionalId",
                table: "AdditionalOptionsServants");

            migrationBuilder.DropColumn(
                name: "AfterBuyAdditionalId",
                table: "UserAdditionalOptions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropColumn(
                name: "AfterBuyAdditionalId",
                table: "AdditionalOptionsServants");

            migrationBuilder.AddColumn<long>(
                name: "AdditionalOptionsId",
                table: "AfterBuyAdditionals",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServantId",
                table: "AfterBuyAdditionals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AfterBuyAdditionals_AdditionalOptionsId",
                table: "AfterBuyAdditionals",
                column: "AdditionalOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AfterBuyAdditionals_ServantId",
                table: "AfterBuyAdditionals",
                column: "ServantId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionals_AdditionalOptions_AdditionalOptionsId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropForeignKey(
                name: "FK_AfterBuyAdditionals_Servants_ServantId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropIndex(
                name: "IX_AfterBuyAdditionals_AdditionalOptionsId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropIndex(
                name: "IX_AfterBuyAdditionals_ServantId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropColumn(
                name: "AdditionalOptionsId",
                table: "AfterBuyAdditionals");

            migrationBuilder.DropColumn(
                name: "ServantId",
                table: "AfterBuyAdditionals");

            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalId",
                table: "UserAdditionalOptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AfterBuyAdditionals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "AfterBuyAdditionals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalId",
                table: "AdditionalOptionsServants",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalOptions_AfterBuyAdditionalId",
                table: "UserAdditionalOptions",
                column: "AfterBuyAdditionalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOptionsServants_AfterBuyAdditionalId",
                table: "AdditionalOptionsServants",
                column: "AfterBuyAdditionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalOptionsServants_AfterBuyAdditionals_AfterBuyAddit~",
                table: "AdditionalOptionsServants",
                column: "AfterBuyAdditionalId",
                principalTable: "AfterBuyAdditionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdditionalOptions_AfterBuyAdditionals_AfterBuyAdditiona~",
                table: "UserAdditionalOptions",
                column: "AfterBuyAdditionalId",
                principalTable: "AfterBuyAdditionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
