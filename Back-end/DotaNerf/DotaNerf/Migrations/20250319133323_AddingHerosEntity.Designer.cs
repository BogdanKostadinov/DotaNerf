﻿// <auto-generated />
using System;
using DotaNerf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotaNerf.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250319133323_AddingHerosEntity")]
    partial class AddingHerosEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotaNerf.Models.GameStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Assists")
                        .HasColumnType("int");

                    b.Property<int?>("Deaths")
                        .HasColumnType("int");

                    b.Property<int?>("GameDuration")
                        .HasColumnType("int");

                    b.Property<int>("GameResult")
                        .HasColumnType("int");

                    b.Property<double?>("Gpm")
                        .HasColumnType("float");

                    b.Property<int>("HeroPlayedId")
                        .HasColumnType("int");

                    b.Property<int?>("Kills")
                        .HasColumnType("int");

                    b.Property<int?>("LastHits")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Xpm")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HeroPlayedId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameStats");
                });

            modelBuilder.Entity("DotaNerf.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Abaddon"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alchemist"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ancient Apparition"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Anti-Mage"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Arc Warden"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Axe"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bane"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Batrider"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Beastmaster"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Bloodseeker"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Bounty Hunter"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Brewmaster"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Bristleback"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Broodmother"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Centaur Warrunner"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Chaos Knight"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Chen"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Clinkz"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Clockwerk"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Crystal Maiden"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Dark Seer"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Dark Willow"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Dawnbreaker"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Dazzle"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Death Prophet"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Disruptor"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Doom"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Dragon Knight"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Drow Ranger"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Earth Spirit"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Earthshaker"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Elder Titan"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Ember Spirit"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Enchantress"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Enigma"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Faceless Void"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Grimstroke"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Gyrocopter"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Hoodwink"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Huskar"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Invoker"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Io"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Jakiro"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Juggernaut"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Keeper of the Light"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Kunkka"
                        },
                        new
                        {
                            Id = 121,
                            Name = "Kez"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Legion Commander"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Leshrac"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Lich"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Lifestealer"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Lina"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Lion"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Lone Druid"
                        },
                        new
                        {
                            Id = 54,
                            Name = "Luna"
                        },
                        new
                        {
                            Id = 55,
                            Name = "Lycan"
                        },
                        new
                        {
                            Id = 56,
                            Name = "Magnus"
                        },
                        new
                        {
                            Id = 57,
                            Name = "Marci"
                        },
                        new
                        {
                            Id = 58,
                            Name = "Mars"
                        },
                        new
                        {
                            Id = 59,
                            Name = "Medusa"
                        },
                        new
                        {
                            Id = 60,
                            Name = "Meepo"
                        },
                        new
                        {
                            Id = 61,
                            Name = "Mirana"
                        },
                        new
                        {
                            Id = 62,
                            Name = "Monkey King"
                        },
                        new
                        {
                            Id = 63,
                            Name = "Morphling"
                        },
                        new
                        {
                            Id = 64,
                            Name = "Muerta"
                        },
                        new
                        {
                            Id = 65,
                            Name = "Naga Siren"
                        },
                        new
                        {
                            Id = 66,
                            Name = "Nature's Prophet"
                        },
                        new
                        {
                            Id = 67,
                            Name = "Necrophos"
                        },
                        new
                        {
                            Id = 68,
                            Name = "Night Stalker"
                        },
                        new
                        {
                            Id = 69,
                            Name = "Nyx Assassin"
                        },
                        new
                        {
                            Id = 70,
                            Name = "Ogre Magi"
                        },
                        new
                        {
                            Id = 71,
                            Name = "Omniknight"
                        },
                        new
                        {
                            Id = 72,
                            Name = "Oracle"
                        },
                        new
                        {
                            Id = 73,
                            Name = "Outworld Destroyer"
                        },
                        new
                        {
                            Id = 74,
                            Name = "Pangolier"
                        },
                        new
                        {
                            Id = 75,
                            Name = "Phantom Assassin"
                        },
                        new
                        {
                            Id = 76,
                            Name = "Phantom Lancer"
                        },
                        new
                        {
                            Id = 77,
                            Name = "Phoenix"
                        },
                        new
                        {
                            Id = 78,
                            Name = "Primal Beast"
                        },
                        new
                        {
                            Id = 79,
                            Name = "Puck"
                        },
                        new
                        {
                            Id = 80,
                            Name = "Pudge"
                        },
                        new
                        {
                            Id = 81,
                            Name = "Pugna"
                        },
                        new
                        {
                            Id = 82,
                            Name = "Queen of Pain"
                        },
                        new
                        {
                            Id = 83,
                            Name = "Razor"
                        },
                        new
                        {
                            Id = 84,
                            Name = "Riki"
                        },
                        new
                        {
                            Id = 85,
                            Name = "Rubick"
                        },
                        new
                        {
                            Id = 120,
                            Name = "Ringmaster"
                        },
                        new
                        {
                            Id = 86,
                            Name = "Sand King"
                        },
                        new
                        {
                            Id = 87,
                            Name = "Shadow Demon"
                        },
                        new
                        {
                            Id = 88,
                            Name = "Shadow Fiend"
                        },
                        new
                        {
                            Id = 89,
                            Name = "Shadow Shaman"
                        },
                        new
                        {
                            Id = 90,
                            Name = "Silencer"
                        },
                        new
                        {
                            Id = 91,
                            Name = "Skywrath Mage"
                        },
                        new
                        {
                            Id = 92,
                            Name = "Slardar"
                        },
                        new
                        {
                            Id = 93,
                            Name = "Slark"
                        },
                        new
                        {
                            Id = 94,
                            Name = "Snapfire"
                        },
                        new
                        {
                            Id = 95,
                            Name = "Sniper"
                        },
                        new
                        {
                            Id = 96,
                            Name = "Spectre"
                        },
                        new
                        {
                            Id = 97,
                            Name = "Spirit Breaker"
                        },
                        new
                        {
                            Id = 98,
                            Name = "Storm Spirit"
                        },
                        new
                        {
                            Id = 99,
                            Name = "Sven"
                        },
                        new
                        {
                            Id = 100,
                            Name = "Techies"
                        },
                        new
                        {
                            Id = 101,
                            Name = "Templar Assassin"
                        },
                        new
                        {
                            Id = 102,
                            Name = "Terrorblade"
                        },
                        new
                        {
                            Id = 103,
                            Name = "Tidehunter"
                        },
                        new
                        {
                            Id = 104,
                            Name = "Timbersaw"
                        },
                        new
                        {
                            Id = 105,
                            Name = "Tinker"
                        },
                        new
                        {
                            Id = 106,
                            Name = "Tiny"
                        },
                        new
                        {
                            Id = 107,
                            Name = "Treant Protector"
                        },
                        new
                        {
                            Id = 108,
                            Name = "Troll Warlord"
                        },
                        new
                        {
                            Id = 109,
                            Name = "Tusk"
                        },
                        new
                        {
                            Id = 110,
                            Name = "Underlord"
                        },
                        new
                        {
                            Id = 111,
                            Name = "Undying"
                        },
                        new
                        {
                            Id = 112,
                            Name = "Ursa"
                        },
                        new
                        {
                            Id = 113,
                            Name = "Vengeful Spirit"
                        },
                        new
                        {
                            Id = 114,
                            Name = "Venomancer"
                        },
                        new
                        {
                            Id = 115,
                            Name = "Viper"
                        },
                        new
                        {
                            Id = 116,
                            Name = "Void Spirit"
                        },
                        new
                        {
                            Id = 117,
                            Name = "Warlock"
                        },
                        new
                        {
                            Id = 118,
                            Name = "Wraith King"
                        },
                        new
                        {
                            Id = 119,
                            Name = "Zeus"
                        });
                });

            modelBuilder.Entity("DotaNerf.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GamesLost")
                        .HasColumnType("int");

                    b.Property<int>("GamesWon")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.Property<double>("Winrate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"),
                            GamesLost = 3,
                            GamesWon = 6,
                            Name = "dummy",
                            TotalGames = 9,
                            Winrate = 67.0
                        },
                        new
                        {
                            Id = new Guid("b2f29d5e-2d4b-4c8a-9c2e-2d4b5c8a9c2e"),
                            GamesLost = 3,
                            GamesWon = 6,
                            Name = "Stoqn (kolega)",
                            TotalGames = 9,
                            Winrate = 67.0
                        },
                        new
                        {
                            Id = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"),
                            GamesLost = 7,
                            GamesWon = 12,
                            Name = "Veni",
                            TotalGames = 19,
                            Winrate = 63.0
                        },
                        new
                        {
                            Id = new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"),
                            GamesLost = 6,
                            GamesWon = 9,
                            Name = "Kriskata",
                            TotalGames = 15,
                            Winrate = 60.0
                        },
                        new
                        {
                            Id = new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"),
                            GamesLost = 7,
                            GamesWon = 10,
                            Name = "Marto",
                            TotalGames = 17,
                            Winrate = 59.0
                        },
                        new
                        {
                            Id = new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"),
                            GamesLost = 7,
                            GamesWon = 7,
                            Name = "Steli",
                            TotalGames = 14,
                            Winrate = 50.0
                        },
                        new
                        {
                            Id = new Guid("07f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"),
                            GamesLost = 9,
                            GamesWon = 10,
                            Name = "Rumen",
                            TotalGames = 19,
                            Winrate = 52.0
                        },
                        new
                        {
                            Id = new Guid("18f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"),
                            GamesLost = 9,
                            GamesWon = 6,
                            Name = "Bobur Kurva",
                            TotalGames = 15,
                            Winrate = 40.0
                        },
                        new
                        {
                            Id = new Guid("29f99d5e-9f4b-4c8a-9f9e-9f4b2c8a9f9e"),
                            GamesLost = 10,
                            GamesWon = 6,
                            Name = "Dj Misho",
                            TotalGames = 16,
                            Winrate = 38.0
                        },
                        new
                        {
                            Id = new Guid("30f09d5e-0f4b-4c8a-9f0e-0f4b3c8a9f0e"),
                            GamesLost = 12,
                            GamesWon = 7,
                            Name = "Kuncho",
                            TotalGames = 19,
                            Winrate = 37.0
                        },
                        new
                        {
                            Id = new Guid("41f19d5e-1f4b-4c8a-9f1e-1f4b4c8a9f1e"),
                            GamesLost = 4,
                            GamesWon = 1,
                            Name = "Sofiqneca",
                            TotalGames = 5,
                            Winrate = 20.0
                        },
                        new
                        {
                            Id = new Guid("52f29d5e-2f4b-4c8a-9f2e-2f4b5c8a9f2e"),
                            GamesLost = 6,
                            GamesWon = 2,
                            Name = "Vaneto",
                            TotalGames = 8,
                            Winrate = 25.0
                        },
                        new
                        {
                            Id = new Guid("63f39d5e-3f4b-4c8a-9f3e-3f4b6c8a9f3e"),
                            GamesLost = 6,
                            GamesWon = 0,
                            Name = "Mario",
                            TotalGames = 6,
                            Winrate = 0.0
                        });
                });

            modelBuilder.Entity("DotaNerf.Models.GameStats", b =>
                {
                    b.HasOne("DotaNerf.Models.Hero", "HeroPlayed")
                        .WithMany()
                        .HasForeignKey("HeroPlayedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeroPlayed");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DotaNerf.Models.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
