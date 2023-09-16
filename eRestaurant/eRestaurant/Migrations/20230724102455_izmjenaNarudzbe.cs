using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class izmjenaNarudzbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_Uplate_UplataID",
                table: "Narudzbe");

            migrationBuilder.AlterColumn<int>(
                name: "UplataID",
                table: "Narudzbe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_Uplate_UplataID",
                table: "Narudzbe",
                column: "UplataID",
                principalTable: "Uplate",
                principalColumn: "UplataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_Uplate_UplataID",
                table: "Narudzbe");

            migrationBuilder.AlterColumn<int>(
                name: "UplataID",
                table: "Narudzbe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_Uplate_UplataID",
                table: "Narudzbe",
                column: "UplataID",
                principalTable: "Uplate",
                principalColumn: "UplataID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
