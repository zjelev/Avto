using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameSomeColumnsToConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserList",
                table: "Transaks",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserList",
                table: "TipZastrahovki",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserList",
                table: "Lists",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "ListZarabotka",
                table: "Lists",
                newName: "Zarabotka");

            migrationBuilder.RenameColumn(
                name: "ListSlujitel",
                table: "Lists",
                newName: "Slujitel");

            migrationBuilder.RenameColumn(
                name: "ListNumber",
                table: "Lists",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "ListMoto",
                table: "Lists",
                newName: "Moto");

            migrationBuilder.RenameColumn(
                name: "ListIzvan",
                table: "Lists",
                newName: "Izvan");

            migrationBuilder.RenameColumn(
                name: "ListDoma",
                table: "Lists",
                newName: "Doma");

            migrationBuilder.RenameColumn(
                name: "ListData",
                table: "Lists",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Transaks",
                newName: "UserList");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "TipZastrahovki",
                newName: "UserList");

            migrationBuilder.RenameColumn(
                name: "Zarabotka",
                table: "Lists",
                newName: "ListZarabotka");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Lists",
                newName: "UserList");

            migrationBuilder.RenameColumn(
                name: "Slujitel",
                table: "Lists",
                newName: "ListSlujitel");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Lists",
                newName: "ListNumber");

            migrationBuilder.RenameColumn(
                name: "Moto",
                table: "Lists",
                newName: "ListMoto");

            migrationBuilder.RenameColumn(
                name: "Izvan",
                table: "Lists",
                newName: "ListIzvan");

            migrationBuilder.RenameColumn(
                name: "Doma",
                table: "Lists",
                newName: "ListDoma");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Lists",
                newName: "ListData");
        }
    }
}
