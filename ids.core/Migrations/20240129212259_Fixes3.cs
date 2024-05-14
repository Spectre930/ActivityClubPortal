using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ids.core.Migrations
{
    /// <inheritdoc />
    public partial class Fixes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoiningDate",
                table: "Members",
                type: "date",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Members",
                type: "date",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JoiningDate",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldMaxLength: 50);
        }
    }
}
