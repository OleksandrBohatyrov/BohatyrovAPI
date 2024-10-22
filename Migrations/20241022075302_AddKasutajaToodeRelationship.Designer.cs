﻿// <auto-generated />
using BohatyrovAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BohatyrovAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241022075302_AddKasutajaToodeRelationship")]
    partial class AddKasutajaToodeRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BohatyrovAPI.Models.Kasutaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Eesnimi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kasutajanimi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parool")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Perenimi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Kasutajad");
                });

            modelBuilder.Entity("BohatyrovAPI.Models.KasutajaToode", b =>
                {
                    b.Property<int>("KasutajaId")
                        .HasColumnType("int");

                    b.Property<int>("ToodeId")
                        .HasColumnType("int");

                    b.HasKey("KasutajaId", "ToodeId");

                    b.HasIndex("ToodeId");

                    b.ToTable("KasutajaTooted");
                });

            modelBuilder.Entity("BohatyrovAPI.Models.Toode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Tooted");
                });

            modelBuilder.Entity("BohatyrovAPI.Models.KasutajaToode", b =>
                {
                    b.HasOne("BohatyrovAPI.Models.Kasutaja", "Kasutaja")
                        .WithMany("KasutajaTooted")
                        .HasForeignKey("KasutajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BohatyrovAPI.Models.Toode", "Toode")
                        .WithMany("KasutajaTooted")
                        .HasForeignKey("ToodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kasutaja");

                    b.Navigation("Toode");
                });

            modelBuilder.Entity("BohatyrovAPI.Models.Kasutaja", b =>
                {
                    b.Navigation("KasutajaTooted");
                });

            modelBuilder.Entity("BohatyrovAPI.Models.Toode", b =>
                {
                    b.Navigation("KasutajaTooted");
                });
#pragma warning restore 612, 618
        }
    }
}
