using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmobileApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Images");

            migrationBuilder.AddColumn<byte>(
                name: "Image",
                table: "Images",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
