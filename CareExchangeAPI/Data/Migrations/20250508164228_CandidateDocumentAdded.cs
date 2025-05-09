using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CandidateDocumentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateDocID = table.Column<int>(type: "int", nullable: false),
                    CanDocID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Uploaded"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<int>(type: "int", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_Documents_CanDocID",
                        column: x => x.CanDocID,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_UserProfiles_CandidateDocID",
                        column: x => x.CandidateDocID,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_UserProfiles_ReviewedBy",
                        column: x => x.ReviewedBy,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_CandidateDocID",
                table: "CandidateDocuments",
                column: "CandidateDocID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_CanDocID",
                table: "CandidateDocuments",
                column: "CanDocID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_DocumentId",
                table: "CandidateDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_ReviewedBy",
                table: "CandidateDocuments",
                column: "ReviewedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_UserProfileId",
                table: "CandidateDocuments",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDocuments");
        }
    }
}
