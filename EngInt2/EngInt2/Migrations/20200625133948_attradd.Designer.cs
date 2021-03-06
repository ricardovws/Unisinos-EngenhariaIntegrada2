﻿// <auto-generated />
using System;
using EngInt2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EngInt2.Migrations
{
    [DbContext(typeof(EngInt2Context))]
    [Migration("20200625133948_attradd")]
    partial class attradd
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

            modelBuilder.Entity("EngInt2.Models.Configuracoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("horarioFinal");

                    b.Property<DateTime>("horarioInicial");

                    b.Property<bool>("statusReferencia");

                    b.Property<int>("temperaturaIniciar");

                    b.Property<int>("temperaturaTerminar");

                    b.Property<int>("tempoDesligado");

                    b.Property<int>("tempoLigado");

                    b.Property<int>("umidadeIniciar");

                    b.Property<int>("umidadeTerminar");

                    b.HasKey("Id");

                    b.ToTable("Configuracoes");
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
