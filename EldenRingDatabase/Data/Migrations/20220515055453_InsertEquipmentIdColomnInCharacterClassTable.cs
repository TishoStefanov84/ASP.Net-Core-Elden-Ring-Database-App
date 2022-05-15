using Microsoft.EntityFrameworkCore.Migrations;

namespace EldenRingDatabase.Migrations
{
    public partial class InsertEquipmentIdColomnInCharacterClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_CharacterClasses_CharacterClassId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_CharacterClassId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CharacterClassId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "CharacterClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_EquipmentId",
                table: "CharacterClasses",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClasses_Equipment_EquipmentId",
                table: "CharacterClasses",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClasses_Equipment_EquipmentId",
                table: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_CharacterClasses_EquipmentId",
                table: "CharacterClasses");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "CharacterClasses");

            migrationBuilder.AddColumn<int>(
                name: "CharacterClassId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CharacterClassId",
                table: "Equipment",
                column: "CharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_CharacterClasses_CharacterClassId",
                table: "Equipment",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
