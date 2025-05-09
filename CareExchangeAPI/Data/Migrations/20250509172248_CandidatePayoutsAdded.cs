using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CandidatePayoutsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatePayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPCandidateID = table.Column<int>(type: "int", nullable: false),
                    CPShiftID = table.Column<int>(type: "int", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PlatformFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NetPayout = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PayoutStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    PayoutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StripePayoutID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePayouts_Shifts_CPShiftID",
                        column: x => x.CPShiftID,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePayouts_UserProfiles_CPCandidateID",
                        column: x => x.CPCandidateID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePayouts_CPCandidateID",
                table: "CandidatePayouts",
                column: "CPCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePayouts_CPShiftID",
                table: "CandidatePayouts",
                column: "CPShiftID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatePayouts");
        }
    }
}
