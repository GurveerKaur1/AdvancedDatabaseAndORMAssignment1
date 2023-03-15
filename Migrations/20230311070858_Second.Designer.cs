﻿// <auto-generated />
using System;
using AdvancedDatabaseAndORMAssignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvancedDatabaseAndORMAssignment1.Migrations
{
    [DbContext(typeof(AdvancedDatabaseAndORMAssignment1Context))]
    [Migration("20230311070858_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.PlayList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayList");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.PlayListSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlayListId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayListId");

                    b.HasIndex("SongId");

                    b.ToTable("PlayListSong");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.SongContributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("SongId");

                    b.ToTable("SongContributor");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.PlayListSong", b =>
                {
                    b.HasOne("AdvancedDatabaseAndORMAssignment1.Models.PlayList", "PlayList")
                        .WithMany("PlayListSongs")
                        .HasForeignKey("PlayListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvancedDatabaseAndORMAssignment1.Models.Song", "Song")
                        .WithMany("PlayListSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayList");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Song", b =>
                {
                    b.HasOne("AdvancedDatabaseAndORMAssignment1.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.SongContributor", b =>
                {
                    b.HasOne("AdvancedDatabaseAndORMAssignment1.Models.Artist", "Artist")
                        .WithMany("SongContributors")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvancedDatabaseAndORMAssignment1.Models.Song", "Song")
                        .WithMany("SongContributors")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Artist", b =>
                {
                    b.Navigation("SongContributors");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.PlayList", b =>
                {
                    b.Navigation("PlayListSongs");
                });

            modelBuilder.Entity("AdvancedDatabaseAndORMAssignment1.Models.Song", b =>
                {
                    b.Navigation("PlayListSongs");

                    b.Navigation("SongContributors");
                });
#pragma warning restore 612, 618
        }
    }
}
