using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmobileApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CivilState",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CivilState",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
