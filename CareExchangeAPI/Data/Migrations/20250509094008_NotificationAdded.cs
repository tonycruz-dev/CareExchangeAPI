using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NotificationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Shifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationUserID = table.Column<int>(type: "int", nullable: false),
                    RecipientType = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Candidate"),
                    TypeOfNotification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_UserProfiles_NotificationUserID",
                        column: x => x.NotificationUserID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UserProfileId",
                table: "Shifts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationUserID",
                table: "Notifications",
                column: "NotificationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserProfileId",
                table: "Notifications",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_UserProfiles_UserProfileId",
                table: "Shifts",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_UserProfiles_UserProfileId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_UserProfileId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Shifts");
        }
    }
}
