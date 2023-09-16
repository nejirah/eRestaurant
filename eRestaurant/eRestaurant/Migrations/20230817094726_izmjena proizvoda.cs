using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class izmjenaproizvoda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentikacijaToken");

            migrationBuilder.RenameColumn(
                name: "VrijemeEvidentiranja",
                table: "AutentikacijaToken",
                newName: "vrijemeEvidentiranja");

            migrationBuilder.RenameColumn(
                name: "Vrijednost",
                table: "AutentikacijaToken",
                newName: "vrijednost");

            migrationBuilder.RenameColumn(
                name: "KorisnickiNalogId",
                table: "AutentikacijaToken",
                newName: "korisnickiNalogId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AutentikacijaToken",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AutentikacijaToken_KorisnickiNalogId",
                table: "AutentikacijaToken",
                newName: "IX_AutentikacijaToken_korisnickiNalogId");

            migrationBuilder.AddColumn<bool>(
                name: "isFavorite",
                table: "Proizvodi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AutentikacijaToken_KorisnickiNalog_korisnickiNalogId",
                table: "AutentikacijaToken",
                column: "korisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "OsobaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentikacijaToken_KorisnickiNalog_korisnickiNalogId",
                table: "AutentikacijaToken");

            migrationBuilder.DropColumn(
                name: "isFavorite",
                table: "Proizvodi");

            migrationBuilder.RenameColumn(
                name: "vrijemeEvidentiranja",
                table: "AutentikacijaToken",
                newName: "VrijemeEvidentiranja");

            migrationBuilder.RenameColumn(
                name: "vrijednost",
                table: "AutentikacijaToken",
                newName: "Vrijednost");

            migrationBuilder.RenameColumn(
                name: "korisnickiNalogId",
                table: "AutentikacijaToken",
                newName: "KorisnickiNalogId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AutentikacijaToken",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AutentikacijaToken_korisnickiNalogId",
                table: "AutentikacijaToken",
                newName: "IX_AutentikacijaToken_KorisnickiNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "OsobaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
