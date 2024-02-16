﻿// <auto-generated />
using System;
using AgremiacionOdontologica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgremiacionOdontologica.Migrations
{
    [DbContext(typeof(ApiDb))]
    [Migration("20240216071346_uno")]
    partial class uno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Domicilio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("idLocalidad")
                        .HasColumnType("integer");

                    b.Property<int>("numero")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("idLocalidad");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Localidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("codigoPostal")
                        .HasColumnType("integer");

                    b.Property<int>("idProvincia")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("idProvincia");

                    b.ToTable("Localidad");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Odontologo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("dni")
                        .HasColumnType("integer");

                    b.Property<int>("idOdontologoEstado")
                        .HasColumnType("integer");

                    b.Property<int>("matricula")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("idOdontologoEstado");

                    b.ToTable("Odontologo");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.OdontologoEstado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("OdontologoEstado");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Provincia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Bono", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("fecha")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("idBonoEstado")
                        .HasColumnType("integer");

                    b.Property<int>("idObraSocial")
                        .HasColumnType("integer");

                    b.Property<int>("idOdontologo")
                        .HasColumnType("integer");

                    b.Property<int>("idPaciente")
                        .HasColumnType("integer");

                    b.Property<int>("idPractica")
                        .HasColumnType("integer");

                    b.Property<int>("numero")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("idBonoEstado");

                    b.HasIndex("idObraSocial");

                    b.HasIndex("idOdontologo");

                    b.HasIndex("idPaciente");

                    b.HasIndex("idPractica");

                    b.ToTable("Bono");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.BonoEstado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("BonoEstado");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Entrega", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("final")
                        .HasColumnType("integer");

                    b.Property<int>("idObraSocial")
                        .HasColumnType("integer");

                    b.Property<int>("idOdontologo")
                        .HasColumnType("integer");

                    b.Property<int>("inicio")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("idObraSocial");

                    b.HasIndex("idOdontologo");

                    b.ToTable("Entrega");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.ObraSocial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ObraSocial");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Paciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("numeroAfiliado")
                        .HasColumnType("integer");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Practica", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("numero")
                        .HasColumnType("integer");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Practica");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Domicilio", b =>
                {
                    b.HasOne("AgremiacionOdontologica.Controllers.Models.Localidad", "localidad")
                        .WithMany()
                        .HasForeignKey("idLocalidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("localidad");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Localidad", b =>
                {
                    b.HasOne("AgremiacionOdontologica.Controllers.Models.Provincia", "provincia")
                        .WithMany()
                        .HasForeignKey("idProvincia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("provincia");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Controllers.Models.Odontologo", b =>
                {
                    b.HasOne("AgremiacionOdontologica.Controllers.Models.OdontologoEstado", "estado")
                        .WithMany()
                        .HasForeignKey("idOdontologoEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estado");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Bono", b =>
                {
                    b.HasOne("AgremiacionOdontologica.Models.BonoEstado", "estado")
                        .WithMany()
                        .HasForeignKey("idBonoEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgremiacionOdontologica.Models.ObraSocial", "obraSocial")
                        .WithMany()
                        .HasForeignKey("idObraSocial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgremiacionOdontologica.Controllers.Models.Odontologo", "odontologo")
                        .WithMany()
                        .HasForeignKey("idOdontologo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgremiacionOdontologica.Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgremiacionOdontologica.Models.Practica", "practica")
                        .WithMany()
                        .HasForeignKey("idPractica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estado");

                    b.Navigation("obraSocial");

                    b.Navigation("odontologo");

                    b.Navigation("paciente");

                    b.Navigation("practica");
                });

            modelBuilder.Entity("AgremiacionOdontologica.Models.Entrega", b =>
                {
                    b.HasOne("AgremiacionOdontologica.Models.ObraSocial", "obraSocial")
                        .WithMany()
                        .HasForeignKey("idObraSocial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgremiacionOdontologica.Controllers.Models.Odontologo", "odontologo")
                        .WithMany()
                        .HasForeignKey("idOdontologo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("obraSocial");

                    b.Navigation("odontologo");
                });
#pragma warning restore 612, 618
        }
    }
}
