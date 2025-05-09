using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShiftRatingsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShID = table.Column<int>(type: "int", nullable: true),
                    SRRatedByUserID = table.Column<int>(type: "int", nullable: true),
                    CareRatedUserID = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftRatings_Shifts_ShID",
                        column: x => x.ShID,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftRatings_UserProfiles_CareRatedUserID",
                        column: x => x.CareRatedUserID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftRatings_UserProfiles_SRRatedByUserID",
                        column: x => x.SRRatedByUserID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRatings_CareRatedUserID",
                table: "ShiftRatings",
                column: "CareRatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRatings_ShID",
                table: "ShiftRatings",
                column: "ShID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRatings_SRRatedByUserID",
                table: "ShiftRatings",
                column: "SRRatedByUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftRatings");
        }
    }
}
