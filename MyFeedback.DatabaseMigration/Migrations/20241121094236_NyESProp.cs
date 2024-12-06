using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFeedback.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class NyESProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ExitSlips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ExitSlips");
        }
    }
}
