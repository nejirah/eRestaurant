using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class narudzbeizmjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaBezPDV",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "PDV",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "UkupnaCijenaSaPDV",
                table: "Narudzbe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CijenaBezPDV",
                table: "Narudzbe",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PDV",
                table: "Narudzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UkupnaCijenaSaPDV",
                table: "Narudzbe",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
