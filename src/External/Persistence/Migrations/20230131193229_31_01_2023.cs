using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _31012023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainRole_Company_CompanyId",
                table: "MainRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MainRoleUser_MainRole_MainRoleId",
                table: "MainRoleUser");

            migrationBuilder.AlterColumn<string>(
                name: "MainRoleId",
                table: "MainRoleUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "MainRole",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_MainRole_Company_CompanyId",
                table: "MainRole",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainRoleUser_MainRole_MainRoleId",
                table: "MainRoleUser",
                column: "MainRoleId",
                principalTable: "MainRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainRole_Company_CompanyId",
                table: "MainRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MainRoleUser_MainRole_MainRoleId",
                table: "MainRoleUser");

            migrationBuilder.AlterColumn<string>(
                name: "MainRoleId",
                table: "MainRoleUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "MainRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainRole_Company_CompanyId",
                table: "MainRole",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainRoleUser_MainRole_MainRoleId",
                table: "MainRoleUser",
                column: "MainRoleId",
                principalTable: "MainRole",
                principalColumn: "Id");
        }
    }
}
