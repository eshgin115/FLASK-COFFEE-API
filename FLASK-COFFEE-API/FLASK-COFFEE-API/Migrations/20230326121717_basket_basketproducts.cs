using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FLASK_COFFEE_API.Migrations
{
    public partial class basket_basketproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivation_Users_UserId",
                table: "UserActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivation",
                table: "UserActivation");

            migrationBuilder.RenameTable(
                name: "UserActivation",
                newName: "UserActivations");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivation_UserId",
                table: "UserActivations",
                newName: "IX_UserActivations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivations",
                table: "UserActivations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_BasketId",
                table: "BasketProducts",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivations_Users_UserId",
                table: "UserActivations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivations_Users_UserId",
                table: "UserActivations");

            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivations",
                table: "UserActivations");

            migrationBuilder.RenameTable(
                name: "UserActivations",
                newName: "UserActivation");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivations_UserId",
                table: "UserActivation",
                newName: "IX_UserActivation_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivation",
                table: "UserActivation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivation_Users_UserId",
                table: "UserActivation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
