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
    [Migration("20240222231534_ModifyTypeOfContact1")]
    partial class ModifyTypeOfContact1
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
                        .HasColumnType("longtext");

                    b.Property<string>("CodeCourrier")
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DateCourrier")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Expediteur")
                        .HasColumnType("longtext");

                    b.Property<string>("MailCourrier")
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("Obejt")
                        .HasColumnType("longtext");

                    b.Property<string>("Statut")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courriers");
                });
#pragma warning restore 612, 618
        }
    }
}
