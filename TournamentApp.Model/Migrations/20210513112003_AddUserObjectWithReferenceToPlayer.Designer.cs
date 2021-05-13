﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentApp.Model;

namespace TournamentApp.Model.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    [Migration("20210513112003_AddUserObjectWithReferenceToPlayer")]
    partial class AddUserObjectWithReferenceToPlayer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TournamentApp.Model.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsMatchPlayed")
                        .HasColumnType("bit");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<int>("ScorePlayer1")
                        .HasColumnType("int");

                    b.Property<int>("ScorePlayer2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentApp.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TournamentApp.Model.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LoserNodeId")
                        .HasColumnType("int");

                    b.Property<int>("NodeSubRoundId")
                        .HasColumnType("int");

                    b.Property<int>("PreviousRoundId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<string>("TournamentKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinnerNodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoserNodeId");

                    b.HasIndex("NodeSubRoundId");

                    b.HasIndex("PreviousRoundId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerNodeId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("TournamentApp.Model.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("TournamentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentApp.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TournamentApp.Model.Match", b =>
                {
                    b.HasOne("TournamentApp.Model.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("TournamentApp.Model.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");

                    b.HasOne("TournamentApp.Model.Round", null)
                        .WithMany("Matches")
                        .HasForeignKey("RoundId");

                    b.Navigation("Player1");

                    b.Navigation("Player2");
                });

            modelBuilder.Entity("TournamentApp.Model.Round", b =>
                {
                    b.HasOne("TournamentApp.Model.Round", "LoserNode")
                        .WithMany()
                        .HasForeignKey("LoserNodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentApp.Model.Round", "NodeSubRound")
                        .WithMany()
                        .HasForeignKey("NodeSubRoundId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentApp.Model.Round", "PreviousRound")
                        .WithMany()
                        .HasForeignKey("PreviousRoundId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentApp.Model.Tournament", "Tournament")
                        .WithMany("Rounds")
                        .HasForeignKey("TournamentId");

                    b.HasOne("TournamentApp.Model.Round", "WinnerNode")
                        .WithMany()
                        .HasForeignKey("WinnerNodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LoserNode");

                    b.Navigation("NodeSubRound");

                    b.Navigation("PreviousRound");

                    b.Navigation("Tournament");

                    b.Navigation("WinnerNode");
                });

            modelBuilder.Entity("TournamentApp.Model.User", b =>
                {
                    b.HasOne("TournamentApp.Model.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TournamentApp.Model.Round", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("TournamentApp.Model.Tournament", b =>
                {
                    b.Navigation("Rounds");
                });
#pragma warning restore 612, 618
        }
    }
}
