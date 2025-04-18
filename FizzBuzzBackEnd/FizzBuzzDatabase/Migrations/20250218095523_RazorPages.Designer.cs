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
    [Migration("20250218095523_RazorPages")]
    partial class RazorPages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
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

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxRange")
                        .HasColumnType("int");

                    b.Property<int>("MinRange")
                        .HasColumnType("int");

                    b.Property<int>("Timer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Admin",
                            GameName = "Default Game",
                            MaxRange = 100,
                            MinRange = 1,
                            Timer = 60
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

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameRule");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Divisor = 7,
                            GameId = 1,
                            Word = "Foo"
                        },
                        new
                        {
                            Id = 2,
                            Divisor = 13,
                            GameId = 1,
                            Word = "Boo"
                        },
                        new
                        {
                            Id = 3,
                            Divisor = 103,
                            GameId = 1,
                            Word = "Loo"
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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("IncorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId1")
                        .HasColumnType("int");

                    b.Property<int>("Questions")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PlayerId1");

                    b.ToTable("GameSession");
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighScore")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Player");
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
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FizzBuzzDatabase.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FizzBuzzDatabase.Models.Player", null)
                        .WithMany("GameSessions")
                        .HasForeignKey("PlayerId1");

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FizzBuzzDatabase.Models.Game", b =>
                {
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
