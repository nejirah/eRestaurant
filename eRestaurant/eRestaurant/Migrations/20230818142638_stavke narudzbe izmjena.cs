using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class stavkenarudzbeizmjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DodatnaNapomena",
                table: "StavkeNarudzbe");

            migrationBuilder.DropColumn(
                name: "Popust",
                table: "StavkeNarudzbe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DodatnaNapomena",
                table: "StavkeNarudzbe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Popust",
                table: "StavkeNarudzbe",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
