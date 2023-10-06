using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKeysToImportData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kilometris",
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
                name: "Motos",
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
                name: "Normas",
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
                name: "Otdels",
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
                name: "Transaks",
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Kilometris");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Normas");

            migrationBuilder.DropTable(
                name: "Otdels");

            migrationBuilder.DropTable(
                name: "Slujiteli");

            migrationBuilder.DropTable(
                name: "TipZastrahovki");

            migrationBuilder.DropTable(
                name: "Transaks");

            migrationBuilder.DropTable(
                name: "Zastrahovki");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
