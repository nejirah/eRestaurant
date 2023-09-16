using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class kuponi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KuponiKorisnika",
                columns: table => new
                {
                    KuponiKorisnikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KuponID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KuponiKorisnika", x => x.KuponiKorisnikaID);
                    table.ForeignKey(
                        name: "FK_KuponiKorisnika_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KuponiKorisnika_Kuponi_KuponID",
                        column: x => x.KuponID,
                        principalTable: "Kuponi",
                        principalColumn: "KuponID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KuponiKorisnika_KorisnikID",
                table: "KuponiKorisnika",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KuponiKorisnika_KuponID",
                table: "KuponiKorisnika",
                column: "KuponID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KuponiKorisnika");
        }
    }
}
