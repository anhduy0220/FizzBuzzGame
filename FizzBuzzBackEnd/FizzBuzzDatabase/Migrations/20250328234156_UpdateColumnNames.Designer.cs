﻿// <auto-generated />
using System;
using FizzBuzzDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FizzBuzzDatabase.Migrations
{
    [DbContext(typeof(GameDB))]
    [Migration("20250328234156_UpdateColumnNames")]
    partial class UpdateColumnNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FizzBuzzDatabase.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Game", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "",
                            Name = "FooBooLoo"
                        },
                        new
                        {
                            Id = 2,
                            Author = "",
                            Name = "FizzBuzz"
                        });
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.GameRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Divisor")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Replacement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameRule", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Divisor = 7,
                            GameId = 0,
                            Replacement = "Foo"
                        },
                        new
                        {
                            Id = 2,
                            Divisor = 13,
                            GameId = 0,
                            Replacement = "Boo"
                        },
                        new
                        {
                            Id = 3,
                            Divisor = 103,
                            GameId = 0,
                            Replacement = "Loo"
                        });
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.GameSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("IncorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameSession", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswers = 3,
                            Duration = 60,
                            GameId = 1,
                            IncorrectAnswers = 1,
                            PlayerId = 1,
                            StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CorrectAnswers = 2,
                            Duration = 45,
                            GameId = 2,
                            IncorrectAnswers = 2,
                            PlayerId = 2,
                            StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Player", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob"
                        });
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.GameRule", b =>
                {
                    b.HasOne("FizzBuzzDatabase.Models.Game", "Game")
                        .WithMany("Rules")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.GameSession", b =>
                {
                    b.HasOne("FizzBuzzDatabase.Models.Game", "Game")
                        .WithMany("GameSessions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FizzBuzzDatabase.Models.Player", "Player")
                        .WithMany("GameSessions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.Game", b =>
                {
                    b.Navigation("GameSessions");

                    b.Navigation("Rules");
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.Player", b =>
                {
                    b.Navigation("GameSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
