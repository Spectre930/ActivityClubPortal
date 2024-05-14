using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ids.core.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Profession = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guides__3214EC07376882AC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Orders = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lookups__3214EC070D66A87F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    EmergencyNumber = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC07395D21A9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: false),
                    Cost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LookupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Events__3214EC07F802EFC2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Events__LookupId__5629CD9C",
                        column: x => x.LookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersRol__49E4C579D70DD5CF", x => new { x.UsersId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UsersRole__Roles__5165187F",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventGuide",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    GuidesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventsGu__8A1E2D5275C69368", x => new { x.EventsId, x.GuidesId });
                    table.ForeignKey(
                        name: "FK__EventsGui__Event__60A75C0F",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__EventsGui__Guide__619B8048",
                        column: x => x.GuidesId,
                        principalTable: "Guides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventsMembers",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventsMe__A95F8D5D0993C128", x => new { x.EventsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_EventsMembers_Members",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__EventsMem__Event__5CD6CB2B",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventGuide_GuidesId",
                table: "EventGuide",
                column: "GuidesId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LookupId",
                table: "Events",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsMembers_MembersId",
                table: "EventsMembers",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RolesId",
                table: "UsersRoles",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGuide");

            migrationBuilder.DropTable(
                name: "EventsMembers");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Lookups");
        }
    }
}
