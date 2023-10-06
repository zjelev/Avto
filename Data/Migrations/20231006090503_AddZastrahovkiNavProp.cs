using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddZastrahovkiNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Zastrahovki_TipZastrahovkaID",
                table: "Zastrahovki",
                column: "TipZastrahovkaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zastrahovki_TipZastrahovki_TipZastrahovkaID",
                table: "Zastrahovki",
                column: "TipZastrahovkaID",
                principalTable: "TipZastrahovki",
                principalColumn: "TipZastrahovkiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zastrahovki_TipZastrahovki_TipZastrahovkaID",
                table: "Zastrahovki");

            migrationBuilder.DropIndex(
                name: "IX_Zastrahovki_TipZastrahovkaID",
                table: "Zastrahovki");
        }
    }
}
