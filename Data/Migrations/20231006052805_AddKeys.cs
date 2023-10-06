using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "List",
                newName: "Lists");

            migrationBuilder.RenameColumn(
                name: "SlujitelID",
                table: "Slujiteli",
                newName: "SlujitelId");

            migrationBuilder.RenameColumn(
                name: "OtdelID",
                table: "Otdels",
                newName: "OtdelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Normas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MotoID",
                table: "Motos",
                newName: "MotoId");

            migrationBuilder.RenameColumn(
                name: "ListID",
                table: "Lists",
                newName: "ListId");

            migrationBuilder.AlterColumn<int>(
                name: "ZastrahovkiID",
                table: "Zastrahovki",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TransID",
                table: "Transaks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TipZastrahovkiID",
                table: "TipZastrahovki",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SlujitelId",
                table: "Slujiteli",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "OtdelId",
                table: "Otdels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserList",
                table: "Normas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TekushtaData",
                table: "Normas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Normas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "Motos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "KMID",
                table: "Kilometris",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "Lists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zastrahovki",
                table: "Zastrahovki",
                column: "ZastrahovkiID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaks",
                table: "Transaks",
                column: "TransID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipZastrahovki",
                table: "TipZastrahovki",
                column: "TipZastrahovkiID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slujiteli",
                table: "Slujiteli",
                column: "SlujitelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Otdels",
                table: "Otdels",
                column: "OtdelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Normas",
                table: "Normas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motos",
                table: "Motos",
                column: "MotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kilometris",
                table: "Kilometris",
                column: "KMID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lists",
                table: "Lists",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Zastrahovki",
                table: "Zastrahovki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaks",
                table: "Transaks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipZastrahovki",
                table: "TipZastrahovki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slujiteli",
                table: "Slujiteli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Otdels",
                table: "Otdels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Normas",
                table: "Normas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motos",
                table: "Motos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kilometris",
                table: "Kilometris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lists",
                table: "Lists");

            migrationBuilder.RenameTable(
                name: "Lists",
                newName: "List");

            migrationBuilder.RenameColumn(
                name: "SlujitelId",
                table: "Slujiteli",
                newName: "SlujitelID");

            migrationBuilder.RenameColumn(
                name: "OtdelId",
                table: "Otdels",
                newName: "OtdelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Normas",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MotoId",
                table: "Motos",
                newName: "MotoID");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "List",
                newName: "ListID");

            migrationBuilder.AlterColumn<int>(
                name: "ZastrahovkiID",
                table: "Zastrahovki",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TransID",
                table: "Transaks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TipZastrahovkiID",
                table: "TipZastrahovki",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SlujitelID",
                table: "Slujiteli",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "OtdelID",
                table: "Otdels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserList",
                table: "Normas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TekushtaData",
                table: "Normas",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Normas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MotoID",
                table: "Motos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "KMID",
                table: "Kilometris",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ListID",
                table: "List",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
