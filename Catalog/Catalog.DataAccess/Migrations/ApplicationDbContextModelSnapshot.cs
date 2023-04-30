﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using Catalog.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BoardGameCategory", b =>
                {
                    b.Property<Guid>("BoardGameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("BoardGameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardGameCategory");
                });

            modelBuilder.Entity("BoardGameMechanic", b =>
                {
                    b.Property<Guid>("BoardGameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MechanicId")
                        .HasColumnType("uuid");

                    b.HasKey("BoardGameId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("BoardGameMechanic");
                });

            modelBuilder.Entity("Catalog.Entites.Common.BoardGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("Catalog.Entites.Common.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Catalog.Entites.Common.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Catalog.Entites.Common.Mechanic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("BoardGameCategory", b =>
                {
                    b.HasOne("Catalog.Entites.Common.BoardGame", null)
                        .WithMany()
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Entites.Common.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameMechanic", b =>
                {
                    b.HasOne("Catalog.Entites.Common.BoardGame", null)
                        .WithMany()
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Entites.Common.Mechanic", null)
                        .WithMany()
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catalog.Entites.Common.BoardGame", b =>
                {
                    b.HasOne("Catalog.Entites.Common.Brand", "Brand")
                        .WithMany("BoardGames")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Catalog.Entites.Common.Brand", b =>
                {
                    b.Navigation("BoardGames");
                });
#pragma warning restore 612, 618
        }
    }
}
