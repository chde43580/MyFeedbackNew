using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFeedback.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrincipalToCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExitSlips_ExitSlipId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalEmail",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExitSlips_ExitSlipId",
                table: "Questions",
                column: "ExitSlipId",
                principalTable: "ExitSlips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExitSlips_ExitSlipId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PrincipalEmail",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExitSlips_ExitSlipId",
                table: "Questions",
                column: "ExitSlipId",
                principalTable: "ExitSlips",
                principalColumn: "Id");
        }
    }
}
