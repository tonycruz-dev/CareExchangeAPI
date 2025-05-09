using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShiftOfferUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftOfferShiftID = table.Column<int>(type: "int", nullable: false),
                    ShiftOfferCandidateID = table.Column<int>(type: "int", nullable: false),
                    OfferStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    OfferedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    RespondedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftOffers_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShiftOffers_Shifts_ShiftOfferShiftID",
                        column: x => x.ShiftOfferShiftID,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftOffers_UserProfiles_ShiftOfferCandidateID",
                        column: x => x.ShiftOfferCandidateID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftOffers_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftOffers_ShiftId",
                table: "ShiftOffers",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftOffers_ShiftOfferCandidateID",
                table: "ShiftOffers",
                column: "ShiftOfferCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftOffers_ShiftOfferShiftID",
                table: "ShiftOffers",
                column: "ShiftOfferShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftOffers_UserProfileId",
                table: "ShiftOffers",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftOffers");
        }
    }
}
