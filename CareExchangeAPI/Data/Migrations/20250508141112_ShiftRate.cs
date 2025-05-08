using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShiftRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_AspNetUsers_CreatedByClientUserID",
                table: "Shifts");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByClientUserID",
                table: "Shifts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ShiftAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromShiftId = table.Column<int>(type: "int", nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Shifts_FromShiftId",
                        column: x => x.FromShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Base"),
                    HourlyRate = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftRates_Shifts_Id",
                        column: x => x.Id,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftRates_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_FromShiftId",
                table: "ShiftAssignments",
                column: "FromShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ProfileId",
                table: "ShiftAssignments",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ShiftId",
                table: "ShiftAssignments",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_UserProfileId",
                table: "ShiftAssignments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRates_ShiftId",
                table: "ShiftRates",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_UserProfiles_CreatedByClientUserID",
                table: "Shifts",
                column: "CreatedByClientUserID",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_UserProfiles_CreatedByClientUserID",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "ShiftAssignments");

            migrationBuilder.DropTable(
                name: "ShiftRates");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByClientUserID",
                table: "Shifts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_AspNetUsers_CreatedByClientUserID",
                table: "Shifts",
                column: "CreatedByClientUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
