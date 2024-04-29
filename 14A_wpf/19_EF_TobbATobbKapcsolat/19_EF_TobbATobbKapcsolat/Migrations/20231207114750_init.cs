using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _19_EF_TobbATobbKapcsolat.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tanulo",
                columns: table => new
                {
                    tanuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tanuloNev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    szuletesiDatum = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanulo", x => x.tanuloId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teszt",
                columns: table => new
                {
                    tesztId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tesztMegnevezes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teszt", x => x.tesztId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TesztEredmenyek",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tanuloId = table.Column<int>(type: "int", nullable: false),
                    tesztId = table.Column<int>(type: "int", nullable: false),
                    eredmeny = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesztEredmenyek", x => x.id);
                    table.ForeignKey(
                        name: "FK_TesztEredmenyek_Tanulo_tanuloId",
                        column: x => x.tanuloId,
                        principalTable: "Tanulo",
                        principalColumn: "tanuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TesztEredmenyek_Teszt_tesztId",
                        column: x => x.tesztId,
                        principalTable: "Teszt",
                        principalColumn: "tesztId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TesztEredmenyek_tanuloId",
                table: "TesztEredmenyek",
                column: "tanuloId");

            migrationBuilder.CreateIndex(
                name: "IX_TesztEredmenyek_tesztId",
                table: "TesztEredmenyek",
                column: "tesztId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TesztEredmenyek");

            migrationBuilder.DropTable(
                name: "Tanulo");

            migrationBuilder.DropTable(
                name: "Teszt");
        }
    }
}
