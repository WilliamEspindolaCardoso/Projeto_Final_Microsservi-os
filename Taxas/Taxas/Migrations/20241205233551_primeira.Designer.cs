﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taxas;

#nullable disable

namespace Taxas.Migrations
{
    [DbContext(typeof(TaxasContext))]
    [Migration("20241205233551_primeira")]
    partial class primeira
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Taxas.Models.Taxa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResidenciaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Taxas");
                });
#pragma warning restore 612, 618
        }
    }
}