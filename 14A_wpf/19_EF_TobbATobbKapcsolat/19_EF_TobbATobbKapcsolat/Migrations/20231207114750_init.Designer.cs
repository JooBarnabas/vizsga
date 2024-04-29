﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _19_EF_TobbATobbKapcsolat;

#nullable disable

namespace _19_EF_TobbATobbKapcsolat.Migrations
{
    [DbContext(typeof(IskolaContext))]
    [Migration("20231207114750_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_19_EF_TobbATobbKapcsolat.Tanulo", b =>
                {
                    b.Property<int>("tanuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("szuletesiDatum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("tanuloNev")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("tanuloId");

                    b.ToTable("Tanulo");
                });

            modelBuilder.Entity("_19_EF_TobbATobbKapcsolat.Teszt", b =>
                {
                    b.Property<int>("tesztId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("tesztMegnevezes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("tesztId");

                    b.ToTable("Teszt");
                });

            modelBuilder.Entity("_19_EF_TobbATobbKapcsolat.TesztEredmenyek", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("eredmeny")
                        .HasColumnType("int");

                    b.Property<int>("tanuloId")
                        .HasColumnType("int");

                    b.Property<int>("tesztId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tanuloId");

                    b.HasIndex("tesztId");

                    b.ToTable("TesztEredmenyek");
                });

            modelBuilder.Entity("_19_EF_TobbATobbKapcsolat.TesztEredmenyek", b =>
                {
                    b.HasOne("_19_EF_TobbATobbKapcsolat.Tanulo", "Tanulo")
                        .WithMany()
                        .HasForeignKey("tanuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_19_EF_TobbATobbKapcsolat.Teszt", "Teszt")
                        .WithMany()
                        .HasForeignKey("tesztId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tanulo");

                    b.Navigation("Teszt");
                });
#pragma warning restore 612, 618
        }
    }
}
