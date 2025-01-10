﻿// <auto-generated />
using System;
using MagicVilla_Api_Udemy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_Api_Udemy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110133707_LocalUserTableAdded")]
    partial class LocalUserTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_Api_Udemy.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");
                });

            modelBuilder.Entity("MagicVilla_Api_Udemy.Models.VillaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("SqFt")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VillasTable", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Pool, WiFi, Parking",
                            CreatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7863),
                            Description = "A beautiful villa with a stunning ocean view, perfect for a relaxing getaway.",
                            ImageUrl = "https://example.com/images/oceanviewvilla.jpg",
                            Name = "Ocean View Villa",
                            Rate = 250.5,
                            SqFt = 2000,
                            UpdatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7873)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Fireplace, Hot Tub, WiFi",
                            CreatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7876),
                            Description = "A cozy retreat in the mountains, ideal for nature lovers and adventure seekers.",
                            ImageUrl = "https://example.com/images/mountainretreat.jpg",
                            Name = "Mountain Retreat",
                            Rate = 180.75,
                            SqFt = 1500,
                            UpdatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7876)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Gym, Elevator, WiFi",
                            CreatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7878),
                            Description = "A modern loft in the heart of the city with easy access to all major attractions.",
                            ImageUrl = "https://example.com/images/cityloft.jpg",
                            Name = "City Loft",
                            Rate = 300.0,
                            SqFt = 1200,
                            UpdatedAt = new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7879)
                        });
                });

            modelBuilder.Entity("MagicVilla_Api_Udemy.Models.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaID")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaID");

                    b.ToTable("VillaNumber");
                });

            modelBuilder.Entity("MagicVilla_Api_Udemy.Models.VillaNumber", b =>
                {
                    b.HasOne("MagicVilla_Api_Udemy.Models.VillaModel", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
