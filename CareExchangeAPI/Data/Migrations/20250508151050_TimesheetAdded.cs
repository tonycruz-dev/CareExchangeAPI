using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class TimesheetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimesheetShiftId = table.Column<int>(type: "int", nullable: true),
                    TimesheetUserPrifileId = table.Column<int>(type: "int", nullable: true),
                    TimesheetClientID = table.Column<int>(type: "int", nullable: true),
                    SubmittedByCandidate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApprovedByClient = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Rejected = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SignedOffBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CareHomeClientId = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_CareHomeClients_CareHomeClientId",
                        column: x => x.CareHomeClientId,
                        principalTable: "CareHomeClients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Timesheets_CareHomeClients_TimesheetClientID",
                        column: x => x.TimesheetClientID,
                        principalTable: "CareHomeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheets_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Timesheets_Shifts_TimesheetShiftId",
                        column: x => x.TimesheetShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheets_UserProfiles_TimesheetUserPrifileId",
                        column: x => x.TimesheetUserPrifileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheets_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_CareHomeClientId",
                table: "Timesheets",
                column: "CareHomeClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ShiftId",
                table: "Timesheets",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TimesheetClientID",
                table: "Timesheets",
                column: "TimesheetClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TimesheetShiftId",
                table: "Timesheets",
                column: "TimesheetShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TimesheetUserPrifileId",
                table: "Timesheets",
                column: "TimesheetUserPrifileId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_UserProfileId",
                table: "Timesheets",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");
        }
    }
}
