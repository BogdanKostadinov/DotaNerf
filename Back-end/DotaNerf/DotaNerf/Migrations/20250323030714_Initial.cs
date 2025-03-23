using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotaNerf.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinningTeam = table.Column<int>(type: "int", nullable: false),
                    RadiantTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DireTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_DireTeamId",
                        column: x => x.DireTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_RadiantTeamId",
                        column: x => x.RadiantTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winrate = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TotalGames = table.Column<int>(type: "int", nullable: false),
                    GamesWon = table.Column<int>(type: "int", nullable: false),
                    GamesLost = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => new { x.GamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Deaths = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Assists = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameStats_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Abaddon" },
                    { 2, "Alchemist" },
                    { 3, "Ancient Apparition" },
                    { 4, "Anti-Mage" },
                    { 5, "Arc Warden" },
                    { 6, "Axe" },
                    { 7, "Bane" },
                    { 8, "Batrider" },
                    { 9, "Beastmaster" },
                    { 10, "Bloodseeker" },
                    { 11, "Bounty Hunter" },
                    { 12, "Brewmaster" },
                    { 13, "Bristleback" },
                    { 14, "Broodmother" },
                    { 15, "Centaur Warrunner" },
                    { 16, "Chaos Knight" },
                    { 17, "Chen" },
                    { 18, "Clinkz" },
                    { 19, "Clockwerk" },
                    { 20, "Crystal Maiden" },
                    { 21, "Dark Seer" },
                    { 22, "Dark Willow" },
                    { 23, "Dawnbreaker" },
                    { 24, "Dazzle" },
                    { 25, "Death Prophet" },
                    { 26, "Disruptor" },
                    { 27, "Doom" },
                    { 28, "Dragon Knight" },
                    { 29, "Drow Ranger" },
                    { 30, "Earth Spirit" },
                    { 31, "Earthshaker" },
                    { 32, "Elder Titan" },
                    { 33, "Ember Spirit" },
                    { 34, "Enchantress" },
                    { 35, "Enigma" },
                    { 36, "Faceless Void" },
                    { 37, "Grimstroke" },
                    { 38, "Gyrocopter" },
                    { 39, "Hoodwink" },
                    { 40, "Huskar" },
                    { 41, "Invoker" },
                    { 42, "Io" },
                    { 43, "Jakiro" },
                    { 44, "Juggernaut" },
                    { 45, "Keeper of the Light" },
                    { 46, "Kunkka" },
                    { 47, "Legion Commander" },
                    { 48, "Leshrac" },
                    { 49, "Lich" },
                    { 50, "Lifestealer" },
                    { 51, "Lina" },
                    { 52, "Lion" },
                    { 53, "Lone Druid" },
                    { 54, "Luna" },
                    { 55, "Lycan" },
                    { 56, "Magnus" },
                    { 57, "Marci" },
                    { 58, "Mars" },
                    { 59, "Medusa" },
                    { 60, "Meepo" },
                    { 61, "Mirana" },
                    { 62, "Monkey King" },
                    { 63, "Morphling" },
                    { 64, "Muerta" },
                    { 65, "Naga Siren" },
                    { 66, "Nature's Prophet" },
                    { 67, "Necrophos" },
                    { 68, "Night Stalker" },
                    { 69, "Nyx Assassin" },
                    { 70, "Ogre Magi" },
                    { 71, "Omniknight" },
                    { 72, "Oracle" },
                    { 73, "Outworld Destroyer" },
                    { 74, "Pangolier" },
                    { 75, "Phantom Assassin" },
                    { 76, "Phantom Lancer" },
                    { 77, "Phoenix" },
                    { 78, "Primal Beast" },
                    { 79, "Puck" },
                    { 80, "Pudge" },
                    { 81, "Pugna" },
                    { 82, "Queen of Pain" },
                    { 83, "Razor" },
                    { 84, "Riki" },
                    { 85, "Rubick" },
                    { 86, "Sand King" },
                    { 87, "Shadow Demon" },
                    { 88, "Shadow Fiend" },
                    { 89, "Shadow Shaman" },
                    { 90, "Silencer" },
                    { 91, "Skywrath Mage" },
                    { 92, "Slardar" },
                    { 93, "Slark" },
                    { 94, "Snapfire" },
                    { 95, "Sniper" },
                    { 96, "Spectre" },
                    { 97, "Spirit Breaker" },
                    { 98, "Storm Spirit" },
                    { 99, "Sven" },
                    { 100, "Techies" },
                    { 101, "Templar Assassin" },
                    { 102, "Terrorblade" },
                    { 103, "Tidehunter" },
                    { 104, "Timbersaw" },
                    { 105, "Tinker" },
                    { 106, "Tiny" },
                    { 107, "Treant Protector" },
                    { 108, "Troll Warlord" },
                    { 109, "Tusk" },
                    { 110, "Underlord" },
                    { 111, "Undying" },
                    { 112, "Ursa" },
                    { 113, "Vengeful Spirit" },
                    { 114, "Venomancer" },
                    { 115, "Viper" },
                    { 116, "Void Spirit" },
                    { 117, "Warlock" },
                    { 118, "Wraith King" },
                    { 119, "Zeus" },
                    { 120, "Ringmaster" },
                    { 121, "Kez" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e"), 0 },
                    { new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DireTeamId", "RadiantTeamId", "WinningTeam" },
                values: new object[] { new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"), new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e"), new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e"), 0 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "GamesLost", "GamesWon", "Name", "TeamId", "TotalGames" },
                values: new object[,]
                {
                    { new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), 0, 0, "dummy", new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e"), 0 },
                    { new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), 0, 0, "Veni", new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e"), 0 }
                });

            migrationBuilder.InsertData(
                table: "GameStats",
                columns: new[] { "Id", "Assists", "Deaths", "GameId", "HeroId", "Kills", "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("88889d5e-888b-488a-988e-888b188a988e"), 10, 3, new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"), 1, 5, new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e") },
                    { new Guid("99999d5e-999b-499a-999e-999b399a999e"), 8, 4, new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"), 3, 12, new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayersId",
                table: "GamePlayers",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DireTeamId",
                table: "Games",
                column: "DireTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RadiantTeamId",
                table: "Games",
                column: "RadiantTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_GameId",
                table: "GameStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_HeroId",
                table: "GameStats",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_PlayerId",
                table: "GameStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_TeamId",
                table: "GameStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "GameStats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
