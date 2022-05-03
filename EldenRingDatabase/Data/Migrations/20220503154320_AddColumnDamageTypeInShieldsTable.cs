using Microsoft.EntityFrameworkCore.Migrations;

namespace EldenRingDatabase.Migrations
{
    public partial class AddColumnDamageTypeInShieldsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageTypeId",
                table: "Shields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shields_DamageTypeId",
                table: "Shields",
                column: "DamageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shields_DamageTypes_DamageTypeId",
                table: "Shields",
                column: "DamageTypeId",
                principalTable: "DamageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shields_DamageTypes_DamageTypeId",
                table: "Shields");

            migrationBuilder.DropIndex(
                name: "IX_Shields_DamageTypeId",
                table: "Shields");

            migrationBuilder.DropColumn(
                name: "DamageTypeId",
                table: "Shields");
        }
    }
}
