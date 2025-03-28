﻿// <auto-generated />
using System;
using DotaNerf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotaNerf.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotaNerf.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DireTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RadiantTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WinningTeam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DireTeamId");

                    b.HasIndex("RadiantTeamId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"),
                            DireTeamId = new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e"),
                            RadiantTeamId = new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e"),
                            WinningTeam = 0
                        });
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlayerDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"),
                            Name = "dummy",
                            PlayerDetailsId = new Guid("d5f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e")
                        },
                        new
                        {
                            Id = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"),
                            Name = "Veni",
                            PlayerDetailsId = new Guid("e6f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e")
                        });
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GamesLost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("GamesWon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalGames")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Winrate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("PlayerDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d5f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"),
                            GamesLost = 6,
                            GamesWon = 9,
                            PlayerId = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"),
                            TotalGames = 15,
                            Winrate = 60.0
                        },
                        new
                        {
                            Id = new Guid("e6f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"),
                            GamesLost = 7,
                            GamesWon = 10,
                            PlayerId = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"),
                            TotalGames = 17,
                            Winrate = 59.0
                        });
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerGame", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerGames");
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Assists")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("Deaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HeroPlayedId")
                        .HasColumnType("int");

                    b.Property<int?>("Kills")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("HeroPlayedId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerStats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88889d5e-888b-488a-988e-888b188a988e"),
                            Assists = 10,
                            Deaths = 3,
                            GameId = new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"),
                            HeroPlayedId = 1,
                            Kills = 5,
                            PlayerId = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"),
                            TeamId = new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e")
                        },
                        new
                        {
                            Id = new Guid("99999d5e-999b-499a-999e-999b399a999e"),
                            Assists = 8,
                            Deaths = 4,
                            GameId = new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"),
                            HeroPlayedId = 3,
                            Kills = 12,
                            PlayerId = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"),
                            TeamId = new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e")
                        });
                });

            modelBuilder.Entity("DotaNerf.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e"),
                            Name = 0
                        },
                        new
                        {
                            Id = new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e"),
                            Name = 1
                        });
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("PlayerTeams", (string)null);
                });

            modelBuilder.Entity("DotaNerf.Models.Game", b =>
                {
                    b.HasOne("DotaNerf.Models.Team", "DireTeam")
                        .WithMany("GamesAsDire")
                        .HasForeignKey("DireTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Team", "RadiantTeam")
                        .WithMany("GamesAsRadiant")
                        .HasForeignKey("RadiantTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DireTeam");

                    b.Navigation("RadiantTeam");
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerDetails", b =>
                {
                    b.HasOne("DotaNerf.Models.Player", "Player")
                        .WithOne("PlayerDetails")
                        .HasForeignKey("DotaNerf.Models.PlayerDetails", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerGame", b =>
                {
                    b.HasOne("DotaNerf.Models.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Player", "Player")
                        .WithMany("PlayerGames")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DotaNerf.Models.PlayerStats", b =>
                {
                    b.HasOne("DotaNerf.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Hero", "HeroPlayed")
                        .WithMany()
                        .HasForeignKey("HeroPlayedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Player", "Player")
                        .WithMany("PlayerStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("HeroPlayed");

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.HasOne("DotaNerf.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaNerf.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotaNerf.Models.Game", b =>
                {
                    b.Navigation("PlayerGames");
                });

            modelBuilder.Entity("DotaNerf.Models.Player", b =>
                {
                    b.Navigation("PlayerDetails")
                        .IsRequired();

                    b.Navigation("PlayerGames");

                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("DotaNerf.Models.Team", b =>
                {
                    b.Navigation("GamesAsDire");

                    b.Navigation("GamesAsRadiant");
                });
#pragma warning restore 612, 618
        }
    }
}
