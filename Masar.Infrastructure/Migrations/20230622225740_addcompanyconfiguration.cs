using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcompanyconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanySetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instagram = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Facebook = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TikTok = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Twitter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Youtube = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    About = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletionDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySetting", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Read = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletionDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7941), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ApplicationUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8") },
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(8028), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0e72dfe1-3273-49b0-9115-a6a37ed864cb"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7790), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("45b79a7b-f9a6-4263-b421-ac34a588114e"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7777), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6af46bf4-84d4-42d2-8c18-ee61e6ee884c"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7783), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76b6ea88-9ec6-403c-a29c-166ae4e4be3b"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c14d826b-ce78-4c02-a45e-ade4ffa89d64"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7654), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 1, 57, 40, 143, DateTimeKind.Unspecified).AddTicks(8004), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanySetting");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 294, DateTimeKind.Unspecified).AddTicks(79), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ApplicationUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8") },
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 294, DateTimeKind.Unspecified).AddTicks(183), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0e72dfe1-3273-49b0-9115-a6a37ed864cb"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 293, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("45b79a7b-f9a6-4263-b421-ac34a588114e"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 293, DateTimeKind.Unspecified).AddTicks(9860), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6af46bf4-84d4-42d2-8c18-ee61e6ee884c"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 293, DateTimeKind.Unspecified).AddTicks(9866), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76b6ea88-9ec6-403c-a29c-166ae4e4be3b"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 293, DateTimeKind.Unspecified).AddTicks(9870), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c14d826b-ce78-4c02-a45e-ade4ffa89d64"),
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 293, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 294, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 15, 22, 41, 32, 294, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
