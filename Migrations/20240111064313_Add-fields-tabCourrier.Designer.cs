﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonCourriel.API.Data;

#nullable disable

namespace MonCourriel.API.Migrations
{
    [DbContext(typeof(MonCourrielDbContext))]
    [Migration("20240111064313_Add-fields-tabCourrier")]
    partial class AddfieldstabCourrier
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MonCourriel.API.Models.Courrier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodeCourrier")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCourrier")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Expediteur")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MailCourrier")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Obejt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courriers");
                });
#pragma warning restore 612, 618
        }
    }
}
