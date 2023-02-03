using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _3022023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavigationItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NavigationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavigationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopNavigationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationItemMainRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NavigationItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationItemMainRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavigationItemMainRole_MainRole_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavigationItemMainRole_NavigationItem_NavigationItemId",
                        column: x => x.NavigationItemId,
                        principalTable: "NavigationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavigationItemMainRole_MainRoleId",
                table: "NavigationItemMainRole",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationItemMainRole_NavigationItemId",
                table: "NavigationItemMainRole",
                column: "NavigationItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavigationItemMainRole");

            migrationBuilder.DropTable(
                name: "NavigationItem");
        }
    }
}
