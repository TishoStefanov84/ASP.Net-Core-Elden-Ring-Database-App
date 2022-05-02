using Microsoft.EntityFrameworkCore.Migrations;

namespace EldenRingDatabase.Data.Migrations
{
    public partial class CreateTalismanAndTalismanEffectColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Talismans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talismans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalismanEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TalismanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalismanEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalismanEffects_Talismans_TalismanId",
                        column: x => x.TalismanId,
                        principalTable: "Talismans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalismanEffects_TalismanId",
                table: "TalismanEffects",
                column: "TalismanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalismanEffects");

            migrationBuilder.DropTable(
                name: "Talismans");
        }
    }
}
