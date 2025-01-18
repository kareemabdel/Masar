using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatenames2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_Role_RoleId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_TripPhoto_Trips_TripId",
                table: "TripPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrip_ApplicationUser_UserId",
                table: "UserTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrip_Trips_TripId",
                table: "UserTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_UserTrip_UserTripId",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTrip",
                table: "UserTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripPhoto",
                table: "TripPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "UserTrip",
                newName: "UserTrips");

            migrationBuilder.RenameTable(
                name: "TripPhoto",
                newName: "TripPhotos");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrip_UserId",
                table: "UserTrips",
                newName: "IX_UserTrips_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrip_TripId",
                table: "UserTrips",
                newName: "IX_UserTrips_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_TripPhoto_TripId",
                table: "TripPhotos",
                newName: "IX_TripPhotos_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTrips",
                table: "UserTrips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripPhotos",
                table: "TripPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_Roles_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripPhotos_Trips_TripId",
                table: "TripPhotos",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrips_ApplicationUser_UserId",
                table: "UserTrips",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrips_Trips_TripId",
                table: "UserTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_UserTrips_UserTripId",
                table: "UserTripStatusHistory",
                column: "UserTripId",
                principalTable: "UserTrips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_Roles_RoleId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_TripPhotos_Trips_TripId",
                table: "TripPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrips_ApplicationUser_UserId",
                table: "UserTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrips_Trips_TripId",
                table: "UserTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_UserTrips_UserTripId",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTrips",
                table: "UserTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripPhotos",
                table: "TripPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "UserTrips",
                newName: "UserTrip");

            migrationBuilder.RenameTable(
                name: "TripPhotos",
                newName: "TripPhoto");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrips_UserId",
                table: "UserTrip",
                newName: "IX_UserTrip_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrips_TripId",
                table: "UserTrip",
                newName: "IX_UserTrip_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_TripPhotos_TripId",
                table: "TripPhoto",
                newName: "IX_TripPhoto_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTrip",
                table: "UserTrip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripPhoto",
                table: "TripPhoto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_Role_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripPhoto_Trips_TripId",
                table: "TripPhoto",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrip_ApplicationUser_UserId",
                table: "UserTrip",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrip_Trips_TripId",
                table: "UserTrip",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_UserTrip_UserTripId",
                table: "UserTripStatusHistory",
                column: "UserTripId",
                principalTable: "UserTrip",
                principalColumn: "Id");
        }
    }
}
