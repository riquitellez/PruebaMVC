﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaMVC.Datos;

namespace PruebaMVC.Datos.Migrations
{
    [DbContext(typeof(PruebaMVCContext))]
    [Migration("20190903203840_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PruebaMVC.Datos.Entidades.Comprador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("PrimerApellido")
                        .IsRequired();

                    b.Property<string>("SegundoApellido")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Compradores");
                });
#pragma warning restore 612, 618
        }
    }
}