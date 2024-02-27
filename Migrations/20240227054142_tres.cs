using Microsoft.EntityFrameworkCore.Migrations;

namespace AgremiacionOdontologica.Migrations
{
    public partial class tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idOdontologo",
                table: "Domicilio",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_idOdontologo",
                table: "Domicilio",
                column: "idOdontologo");

            migrationBuilder.AddForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologo",
                table: "Domicilio",
                column: "idOdontologo",
                principalTable: "Odontologo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologo",
                table: "Domicilio");

            migrationBuilder.DropIndex(
                name: "IX_Domicilio_idOdontologo",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "idOdontologo",
                table: "Domicilio");
        }
    }
}
