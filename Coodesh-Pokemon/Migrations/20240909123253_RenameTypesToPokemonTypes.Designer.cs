﻿// <auto-generated />
using Coodesh_Pokemon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coodesh_Pokemon.Migrations
{
    [DbContext(typeof(PokemonMasterContext))]
    [Migration("20240909123253_RenameTypesToPokemonTypes")]
    partial class RenameTypesToPokemonTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Coodesh_Pokemon.Models.PokemonCapture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonMasterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PokemonSprite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PokemonTypes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PokemonMasterId");

                    b.ToTable("PokemonCaptures");
                });

            modelBuilder.Entity("Coodesh_Pokemon.Models.PokemonMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PokemonMasters");
                });

            modelBuilder.Entity("Coodesh_Pokemon.Models.PokemonCapture", b =>
                {
                    b.HasOne("Coodesh_Pokemon.Models.PokemonMaster", "PokemonMaster")
                        .WithMany()
                        .HasForeignKey("PokemonMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
