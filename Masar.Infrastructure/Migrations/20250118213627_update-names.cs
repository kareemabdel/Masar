using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_ApplicationUser_AddedById",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Cities_CityId",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_TripPhoto_Trip_TripId",
                table: "TripPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrip_Trip_TripId",
                table: "UserTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChagedById",
                table: "UserTripStatusHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserTripStatusHistory_ChagedById",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_AddedById",
                table: "Trip");

            migrationBuilder.RenameTable(
                name: "Trip",
                newName: "Trips");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "UserTripStatusHistory",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserTripStatusHistory",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ChagedById",
                table: "UserTripStatusHistory",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "UserTrip",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserTrip",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "TripPhoto",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "TripPhoto",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Role",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Role",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Galleries",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Galleries",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "ContactUs",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ContactUs",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "CompanySettings",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "CompanySettings",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Cities",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Cities",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "AuditTrial",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "AuditTrial",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "ApplicationUserRole",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ApplicationUserRole",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "ApplicationUser",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ApplicationUser",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Trips",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Trips",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "AddedById",
                table: "Trips",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_CityId",
                table: "Trips",
                newName: "IX_Trips_CityId");

            migrationBuilder.AddColumn<Guid>(
                name: "ChangedById",
                table: "UserTripStatusHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "UserTripStatusHistory",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "UserTrip",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "UserTrip",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TripPhoto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "TripPhoto",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Role",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Galleries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Galleries",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ContactUs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "ContactUs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "CompanySettings",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Cities",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AuditTrial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "AuditTrial",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ApplicationUserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "ApplicationUserRole",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "ApplicationUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Trips",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ApplicationUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8") },
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0e72dfe1-3273-49b0-9115-a6a37ed864cb"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("45b79a7b-f9a6-4263-b421-ac34a588114e"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6af46bf4-84d4-42d2-8c18-ee61e6ee884c"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76b6ea88-9ec6-403c-a29c-166ae4e4be3b"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c14d826b-ce78-4c02-a45e-ade4ffa89d64"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_UserTripStatusHistory_ChangedById",
                table: "UserTripStatusHistory",
                column: "ChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TripPhoto_Trips_TripId",
                table: "TripPhoto",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrip_Trips_TripId",
                table: "UserTrip",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChangedById",
                table: "UserTripStatusHistory",
                column: "ChangedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripPhoto_Trips_TripId",
                table: "TripPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrip_Trips_TripId",
                table: "UserTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChangedById",
                table: "UserTripStatusHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserTripStatusHistory_ChangedById",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ChangedById",
                table: "UserTripStatusHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserTripStatusHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserTrip");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserTrip");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TripPhoto");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TripPhoto");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AuditTrial");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AuditTrial");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ApplicationUserRole");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ApplicationUserRole");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "Trip");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserTripStatusHistory",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserTripStatusHistory",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "UserTripStatusHistory",
                newName: "ChagedById");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserTrip",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserTrip",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "TripPhoto",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TripPhoto",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Role",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Role",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Galleries",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Galleries",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ContactUs",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ContactUs",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "CompanySettings",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "CompanySettings",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Cities",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Cities",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "AuditTrial",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "AuditTrial",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ApplicationUserRole",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ApplicationUserRole",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ApplicationUser",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ApplicationUser",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Trip",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Trip",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Trip",
                newName: "AddedById");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_CityId",
                table: "Trip",
                newName: "IX_Trip_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                table: "Trip",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTripStatusHistory_ChagedById",
                table: "UserTripStatusHistory",
                column: "ChagedById");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_AddedById",
                table: "Trip",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_ApplicationUser_AddedById",
                table: "Trip",
                column: "AddedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Cities_CityId",
                table: "Trip",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripPhoto_Trip_TripId",
                table: "TripPhoto",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrip_Trip_TripId",
                table: "UserTrip",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChagedById",
                table: "UserTripStatusHistory",
                column: "ChagedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
