using Microsoft.EntityFrameworkCore.Migrations;

namespace AgremiacionOdontologica.Migrations
{
    public partial class adasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologo",
                table: "Domicilio");

            migrationBuilder.RenameColumn(
                name: "idOdontologo",
                table: "Domicilio",
                newName: "idOdontologoNombre");

            migrationBuilder.RenameIndex(
                name: "IX_Domicilio_idOdontologo",
                table: "Domicilio",
                newName: "IX_Domicilio_idOdontologoNombre");

            migrationBuilder.AddColumn<int>(
                name: "idOdontologoApellido",
                table: "Domicilio",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_idOdontologoApellido",
                table: "Domicilio",
                column: "idOdontologoApellido");

            migrationBuilder.AddForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologoApellido",
                table: "Domicilio",
                column: "idOdontologoApellido",
                principalTable: "Odontologo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologoNombre",
                table: "Domicilio",
                column: "idOdontologoNombre",
                principalTable: "Odontologo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologoApellido",
                table: "Domicilio");

            migrationBuilder.DropForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologoNombre",
                table: "Domicilio");

            migrationBuilder.DropIndex(
                name: "IX_Domicilio_idOdontologoApellido",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "idOdontologoApellido",
                table: "Domicilio");

            migrationBuilder.RenameColumn(
                name: "idOdontologoNombre",
                table: "Domicilio",
                newName: "idOdontologo");

            migrationBuilder.RenameIndex(
                name: "IX_Domicilio_idOdontologoNombre",
                table: "Domicilio",
                newName: "IX_Domicilio_idOdontologo");

            migrationBuilder.AddForeignKey(
                name: "FK_Domicilio_Odontologo_idOdontologo",
                table: "Domicilio",
                column: "idOdontologo",
                principalTable: "Odontologo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
