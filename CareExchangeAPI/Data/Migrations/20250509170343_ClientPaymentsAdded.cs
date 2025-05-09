using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientPaymentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienPaytId = table.Column<int>(type: "int", nullable: false),
                    CPShiftId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountCharged = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StripeTransactionID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CareHomeClientId = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPayments_CareHomeClients_CareHomeClientId",
                        column: x => x.CareHomeClientId,
                        principalTable: "CareHomeClients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientPayments_CareHomeClients_ClienPaytId",
                        column: x => x.ClienPaytId,
                        principalTable: "CareHomeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPayments_Shifts_CPShiftId",
                        column: x => x.CPShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPayments_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftCancellations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCId = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserID = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Approved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_Shifts_SCId",
                        column: x => x.SCId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_UserProfiles_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_UserProfiles_RequestedByUserID",
                        column: x => x.RequestedByUserID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShiftCancellations_UserProfiles_UserProfileId1",
                        column: x => x.UserProfileId1,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_CareHomeClientId",
                table: "ClientPayments",
                column: "CareHomeClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_ClienPaytId",
                table: "ClientPayments",
                column: "ClienPaytId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_CPShiftId",
                table: "ClientPayments",
                column: "CPShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_ShiftId",
                table: "ClientPayments",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_ApprovedBy",
                table: "ShiftCancellations",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_RequestedByUserID",
                table: "ShiftCancellations",
                column: "RequestedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_SCId",
                table: "ShiftCancellations",
                column: "SCId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_ShiftId",
                table: "ShiftCancellations",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_UserProfileId",
                table: "ShiftCancellations",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCancellations_UserProfileId1",
                table: "ShiftCancellations",
                column: "UserProfileId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPayments");

            migrationBuilder.DropTable(
                name: "ShiftCancellations");
        }
    }
}
