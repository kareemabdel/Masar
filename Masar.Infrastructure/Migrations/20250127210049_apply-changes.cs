using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class applychanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_ApplicationUser_AddedByUserName",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_ApplicationUser_ApplicationUserUserName",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrips_ApplicationUser_UserName",
                table: "UserTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChangedByUserName",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Users_AddedByUserName",
                table: "Galleries",
                column: "AddedByUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserUserName",
                table: "UserRoles",
                column: "ApplicationUserUserName",
                principalTable: "Users",
                principalColumn: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrips_Users_UserName",
                table: "UserTrips",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_Users_ChangedByUserName",
                table: "UserTripStatusHistory",
                column: "ChangedByUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Users_AddedByUserName",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserUserName",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrips_Users_UserName",
                table: "UserTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTripStatusHistory_Users_ChangedByUserName",
                table: "UserTripStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_ApplicationUser_AddedByUserName",
                table: "Galleries",
                column: "AddedByUserName",
                principalTable: "ApplicationUser",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_ApplicationUser_ApplicationUserUserName",
                table: "UserRoles",
                column: "ApplicationUserUserName",
                principalTable: "ApplicationUser",
                principalColumn: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrips_ApplicationUser_UserName",
                table: "UserTrips",
                column: "UserName",
                principalTable: "ApplicationUser",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTripStatusHistory_ApplicationUser_ChangedByUserName",
                table: "UserTripStatusHistory",
                column: "ChangedByUserName",
                principalTable: "ApplicationUser",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
