using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ids.core.Migrations
{
    /// <inheritdoc />
    public partial class MemberFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyNumber",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MobileNumber",
                table: "Members",
                type: "numeric(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EmergencyNumber",
                table: "Members",
                type: "numeric(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
