using Microsoft.EntityFrameworkCore.Migrations;

namespace AgremiacionOdontologica.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "codigo",
                table: "ObraSocial",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo",
                table: "ObraSocial");
        }
    }
}
