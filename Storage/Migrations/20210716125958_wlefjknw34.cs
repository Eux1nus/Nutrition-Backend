using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Storage.Migrations
{
    public partial class wlefjknw34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalId",
                table: "UserAdditionalOptions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AfterBuyAdditionalId",
                table: "AdditionalOptionsServants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AfterBuyAdditionals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterBuyAdditionals", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalOptionsServants_AfterBuyAdditionals_AfterBuyAddit~",
                table: "AdditionalOptionsServants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalOptions_AfterBuyAdditionals_AfterBuyAdditiona~",
                table: "UserAdditionalOptions");

            migrationBuilder.DropTable(
                name: "AfterBuyAdditionals");

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
                name: "AfterBuyAdditionalId",
                table: "AdditionalOptionsServants");
        }
    }
}
