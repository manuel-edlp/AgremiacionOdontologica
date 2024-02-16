using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgremiacionOdontologica.Migrations
{
    public partial class uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonoEstado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonoEstado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ObraSocial",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSocial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OdontologoEstado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdontologoEstado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    numeroAfiliado = table.Column<int>(type: "integer", nullable: false),
                    sexo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Practica",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practica", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Odontologo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    matricula = table.Column<int>(type: "integer", nullable: false),
                    dni = table.Column<int>(type: "integer", nullable: false),
                    idOdontologoEstado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontologo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Odontologo_OdontologoEstado_idOdontologoEstado",
                        column: x => x.idOdontologoEstado,
                        principalTable: "OdontologoEstado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    codigoPostal = table.Column<int>(type: "integer", nullable: false),
                    idProvincia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_idProvincia",
                        column: x => x.idProvincia,
                        principalTable: "Provincia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bono",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    idBonoEstado = table.Column<int>(type: "integer", nullable: false),
                    idOdontologo = table.Column<int>(type: "integer", nullable: false),
                    idObraSocial = table.Column<int>(type: "integer", nullable: false),
                    idPaciente = table.Column<int>(type: "integer", nullable: false),
                    idPractica = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bono", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bono_BonoEstado_idBonoEstado",
                        column: x => x.idBonoEstado,
                        principalTable: "BonoEstado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bono_ObraSocial_idObraSocial",
                        column: x => x.idObraSocial,
                        principalTable: "ObraSocial",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bono_Odontologo_idOdontologo",
                        column: x => x.idOdontologo,
                        principalTable: "Odontologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bono_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bono_Practica_idPractica",
                        column: x => x.idPractica,
                        principalTable: "Practica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inicio = table.Column<int>(type: "integer", nullable: false),
                    final = table.Column<int>(type: "integer", nullable: false),
                    idOdontologo = table.Column<int>(type: "integer", nullable: false),
                    idObraSocial = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entrega_ObraSocial_idObraSocial",
                        column: x => x.idObraSocial,
                        principalTable: "ObraSocial",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_Odontologo_idOdontologo",
                        column: x => x.idOdontologo,
                        principalTable: "Odontologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calle = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    idLocalidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Domicilio_Localidad_idLocalidad",
                        column: x => x.idLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bono_idBonoEstado",
                table: "Bono",
                column: "idBonoEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Bono_idObraSocial",
                table: "Bono",
                column: "idObraSocial");

            migrationBuilder.CreateIndex(
                name: "IX_Bono_idOdontologo",
                table: "Bono",
                column: "idOdontologo");

            migrationBuilder.CreateIndex(
                name: "IX_Bono_idPaciente",
                table: "Bono",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Bono_idPractica",
                table: "Bono",
                column: "idPractica");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_idLocalidad",
                table: "Domicilio",
                column: "idLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_idObraSocial",
                table: "Entrega",
                column: "idObraSocial");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_idOdontologo",
                table: "Entrega",
                column: "idOdontologo");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_idProvincia",
                table: "Localidad",
                column: "idProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Odontologo_idOdontologoEstado",
                table: "Odontologo",
                column: "idOdontologoEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bono");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "BonoEstado");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Practica");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "ObraSocial");

            migrationBuilder.DropTable(
                name: "Odontologo");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "OdontologoEstado");
        }
    }
}
