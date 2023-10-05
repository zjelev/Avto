using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityInAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kilometri",
                columns: table => new
                {
                    KMID = table.Column<int>(type: "int", nullable: false),
                    KMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    ListID = table.Column<int>(type: "int", nullable: false),
                    ListNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ListData = table.Column<DateTime>(type: "datetime", nullable: true),
                    ListMoto = table.Column<double>(type: "float", nullable: true),
                    ListSlujitel = table.Column<double>(type: "float", nullable: true),
                    ListZarabotka = table.Column<double>(type: "float", nullable: true),
                    ListIzvan = table.Column<double>(type: "float", nullable: true),
                    ListDoma = table.Column<double>(type: "float", nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    MotoID = table.Column<int>(type: "int", nullable: false),
                    MotoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotoNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    OsnovnaNorma = table.Column<double>(type: "float", nullable: false),
                    GradskaNorma = table.Column<double>(type: "float", nullable: true),
                    RudnikNorma = table.Column<double>(type: "float", nullable: true),
                    OkragNorma = table.Column<double>(type: "float", nullable: true),
                    StolicaNorma = table.Column<double>(type: "float", nullable: true),
                    MqstoNorma = table.Column<double>(type: "float", nullable: true),
                    KlimaNorma = table.Column<double>(type: "float", nullable: true),
                    AgregatNorma = table.Column<double>(type: "float", nullable: true),
                    KlimatikNorma = table.Column<double>(type: "float", nullable: true),
                    PechkaNorma = table.Column<double>(type: "float", nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brak = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Norma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NormaKlimatronik = table.Column<double>(type: "float", nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Otdel",
                columns: table => new
                {
                    OtdelID = table.Column<int>(type: "int", nullable: false),
                    OtdelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Slujiteli",
                columns: table => new
                {
                    SlujitelID = table.Column<int>(type: "int", nullable: false),
                    SlujitelName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    SlujitelNumber = table.Column<int>(type: "int", nullable: false),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TipZastrahovki",
                columns: table => new
                {
                    TipZastrahovkiID = table.Column<int>(type: "int", nullable: false),
                    TipZastrahovki = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transak",
                columns: table => new
                {
                    TransID = table.Column<int>(type: "int", nullable: false),
                    MotoID = table.Column<int>(type: "int", nullable: true),
                    OtdelID = table.Column<int>(type: "int", nullable: true),
                    SlujitelID = table.Column<int>(type: "int", nullable: true),
                    KMID = table.Column<int>(type: "int", nullable: true),
                    ListID = table.Column<int>(type: "int", nullable: true),
                    DateTrans = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KmKm = table.Column<double>(type: "float", nullable: true),
                    OsnovnaTrans = table.Column<double>(type: "float", nullable: true),
                    RudnikTrans = table.Column<double>(type: "float", nullable: true),
                    OkragTrans = table.Column<double>(type: "float", nullable: true),
                    StolicaTrans = table.Column<double>(type: "float", nullable: true),
                    GradskaTrans = table.Column<double>(type: "float", nullable: true),
                    MqstoTrans = table.Column<double>(type: "float", nullable: true),
                    KlimaTrans = table.Column<double>(type: "float", nullable: true),
                    AgregatTrans = table.Column<double>(type: "float", nullable: true),
                    Zarabotka = table.Column<double>(type: "float", nullable: true),
                    Izvan = table.Column<double>(type: "float", nullable: true),
                    Doma = table.Column<double>(type: "float", nullable: true),
                    KlimatikTrans = table.Column<double>(type: "float", nullable: true),
                    PechkaTrans = table.Column<double>(type: "float", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Zastrahovki",
                columns: table => new
                {
                    ZastrahovkiID = table.Column<int>(type: "int", nullable: false),
                    MotoID = table.Column<int>(type: "int", nullable: true),
                    DataStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipZastrahovkaID = table.Column<int>(type: "int", nullable: true),
                    TekushtaData = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kilometri");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Norma");

            migrationBuilder.DropTable(
                name: "Otdel");

            migrationBuilder.DropTable(
                name: "Slujiteli");

            migrationBuilder.DropTable(
                name: "TipZastrahovki");

            migrationBuilder.DropTable(
                name: "Transak");

            migrationBuilder.DropTable(
                name: "Zastrahovki");
        }
    }
}
