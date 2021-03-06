﻿// <auto-generated />
using EngInt2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EngInt2.Migrations
{
    [DbContext(typeof(EngInt2Context))]
    [Migration("20200603195025_newModel")]
    partial class newModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EngInt2.Models.Comandos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Desligado");

                    b.Property<int>("Ligado");

                    b.Property<string>("NomeComponente");

                    b.Property<int>("Status");

                    b.Property<int>("Status_Enum");

                    b.HasKey("Id");

                    b.ToTable("Comandos");
                });

            modelBuilder.Entity("EngInt2.Models.SensorTemperaturaUmidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Temperatura");

                    b.Property<string>("Umidade");

                    b.Property<string>("UmidadeSolo");

                    b.HasKey("Id");

                    b.ToTable("SensorTemperaturaUmidade");
                });
#pragma warning restore 612, 618
        }
    }
}
