using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CareHomeClientAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareHomeClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LegalEntity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CareHomeClientUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareHomeClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareHomeClients_AspNetUsers_CareHomeClientUserID",
                        column: x => x.CareHomeClientUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareHomeClients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CareHomeClientLocations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareHomeClientID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DefaultStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DefaultEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareHomeClientLocations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_CareHomeClientLocations_CareHomeClients_CareHomeClientID",
                        column: x => x.CareHomeClientID,
                        principalTable: "CareHomeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareHomeClientLocations_CareHomeClientID",
                table: "CareHomeClientLocations",
                column: "CareHomeClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CareHomeClients_CareHomeClientUserID",
                table: "CareHomeClients",
                column: "CareHomeClientUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CareHomeClients_UserId",
                table: "CareHomeClients",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareHomeClientLocations");

            migrationBuilder.DropTable(
                name: "CareHomeClients");
        }
    }
}
