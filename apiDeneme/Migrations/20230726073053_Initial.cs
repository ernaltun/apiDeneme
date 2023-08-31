using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiDeneme.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracPlaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AracSofor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CıkısNoktası = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimatNoktası = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
