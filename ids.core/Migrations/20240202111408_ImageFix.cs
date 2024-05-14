using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ids.core.Migrations
{
    /// <inheritdoc />
    public partial class ImageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Lookups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Guides",
                type: "nvarchar(max)",
                nullable: true);


            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Lookups");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

        }
    }
}
