using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareExchangeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExpiryDays = table.Column<int>(type: "int", nullable: true),
                    ClientVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CandidateVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
