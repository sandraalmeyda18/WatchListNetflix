﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WatchListNetflix.Data;

#nullable disable

namespace WatchListNetflix.Data.Migrations
{
    [DbContext(typeof(WatchListNetflixContext))]
    [Migration("20250128162043_ImproveInitalMigration")]
    partial class ImproveInitalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Audiovisual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AudiovisualType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Synopsis")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WatchlistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WatchlistId");

                    b.ToTable("Audiovisuals");

                    b.HasDiscriminator<string>("AudiovisualType").HasValue("Audiovisual");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Watchlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Movie", b =>
                {
                    b.HasBaseType("WatchListNetflix.Model.Entities.Audiovisual");

                    b.Property<int>("EpisodesNumber")
                        .HasColumnType("int");

                    b.Property<bool?>("OnAir")
                        .HasColumnType("bit");

                    b.Property<int>("SeasonsNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Serie", b =>
                {
                    b.HasBaseType("WatchListNetflix.Model.Entities.Audiovisual");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Audiovisual", b =>
                {
                    b.HasOne("WatchListNetflix.Model.Entities.Watchlist", null)
                        .WithMany("Audiovisuals")
                        .HasForeignKey("WatchlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Client", b =>
                {
                    b.HasOne("WatchListNetflix.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Watchlist", b =>
                {
                    b.HasOne("WatchListNetflix.Model.Entities.Client", null)
                        .WithMany("WatchLists")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Client", b =>
                {
                    b.Navigation("WatchLists");
                });

            modelBuilder.Entity("WatchListNetflix.Model.Entities.Watchlist", b =>
                {
                    b.Navigation("Audiovisuals");
                });
#pragma warning restore 612, 618
        }
    }
}
