using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _30012023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainRoleRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoleRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoleRole_MainRole_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainRoleRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainRoleUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoleUser_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainRoleUser_MainRole_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleRole_MainRoleId",
                table: "MainRoleRole",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleRole_RoleId",
                table: "MainRoleRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleUser_CompanyId",
                table: "MainRoleUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleUser_MainRoleId",
                table: "MainRoleUser",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleUser_UserId",
                table: "MainRoleUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainRoleRole");

            migrationBuilder.DropTable(
                name: "MainRoleUser");
        }
    }
}
