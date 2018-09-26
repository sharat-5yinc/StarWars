﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Models;

namespace StarWars.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180926104903_FactionsModelUpdated")]
    partial class FactionsModelUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWars.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterGroupID");

                    b.Property<string>("CharacterName")
                        .HasMaxLength(200);

                    b.Property<int>("CharacterTypeID");

                    b.Property<int?>("FactionID");

                    b.Property<string>("HomePlanet")
                        .HasMaxLength(200);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Purpose")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CharacterGroupID");

                    b.HasIndex("CharacterTypeID");

                    b.HasIndex("FactionID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("StarWars.Models.CharacterGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CharacterGroups");
                });

            modelBuilder.Entity("StarWars.Models.CharacterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterTypeName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CharacterTypes");
                });

            modelBuilder.Entity("StarWars.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EpisodeName");

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("StarshipId");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("EpisodeName")
                        .IsUnique()
                        .HasFilter("[EpisodeName] IS NOT NULL");

                    b.HasIndex("StarshipId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("StarWars.Models.EpisodeCharacter", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("CharacterId");

                    b.HasKey("EpisodeId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("EpisodeCharacter");
                });

            modelBuilder.Entity("StarWars.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FactionName");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("FactionName")
                        .IsUnique()
                        .HasFilter("[FactionName] IS NOT NULL");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("StarWars.Models.Pie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsInStock");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Pies");
                });

            modelBuilder.Entity("StarWars.Models.Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("StarshipName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("StarshipName")
                        .IsUnique()
                        .HasFilter("[StarshipName] IS NOT NULL");

                    b.ToTable("Starships");
                });

            modelBuilder.Entity("StarWars.Models.StarshipCharacter", b =>
                {
                    b.Property<int>("StarshipId");

                    b.Property<int>("CharacterId");

                    b.HasKey("StarshipId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("StarshipCharacter");
                });

            modelBuilder.Entity("StarWars.Models.Character", b =>
                {
                    b.HasOne("StarWars.Models.CharacterGroup", "CharacterGroup")
                        .WithMany()
                        .HasForeignKey("CharacterGroupID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarWars.Models.CharacterType", "CharacterType")
                        .WithMany()
                        .HasForeignKey("CharacterTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarWars.Models.Faction", "Faction")
                        .WithMany("Characters")
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("StarWars.Models.Episode", b =>
                {
                    b.HasOne("StarWars.Models.Starship")
                        .WithMany("AppersIn_Episodes")
                        .HasForeignKey("StarshipId");
                });

            modelBuilder.Entity("StarWars.Models.EpisodeCharacter", b =>
                {
                    b.HasOne("StarWars.Models.Character", "Character")
                        .WithMany("AppersIn_Episodes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarWars.Models.Episode", "Episode")
                        .WithMany("Cast")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarWars.Models.StarshipCharacter", b =>
                {
                    b.HasOne("StarWars.Models.Character", "Character")
                        .WithMany("Starships")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarWars.Models.Starship", "Starship")
                        .WithMany("Characters")
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
