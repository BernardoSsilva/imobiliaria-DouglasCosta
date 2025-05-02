using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmobileApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloudnaryPublicId",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloudnaryPublicId",
                table: "Images");
        }
    }
}
