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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
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
                name: "PlayerDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Winrate = table.Column<double>(type: "float", nullable: false),
                    TotalGames = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GamesWon = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GamesLost = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDetails_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PlayerTeams",
                columns: table => new
                {
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => new { x.PlayersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroPlayedId = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Deaths = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Assists = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Heroes_HeroPlayedId",
                        column: x => x.HeroPlayedId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Players",
                columns: new[] { "Id", "Name", "PlayerDetailsId" },
                values: new object[,]
                {
                    { new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), "dummy", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), "Veni", new Guid("00000000-0000-0000-0000-000000000000") }
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
                table: "PlayerDetails",
                columns: new[] { "Id", "GamesLost", "GamesWon", "PlayerId", "TotalGames", "Winrate" },
                values: new object[,]
                {
                    { new Guid("d5f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"), 6, 9, new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), 15, 60.0 },
                    { new Guid("e6f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), 7, 10, new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), 17, 59.0 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStats",
                columns: new[] { "Id", "Assists", "Deaths", "GameId", "HeroPlayedId", "Kills", "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("88889d5e-888b-488a-988e-888b188a988e"), 10, 3, new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"), 1, 5, new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e") },
                    { new Guid("99999d5e-999b-499a-999e-999b399a999e"), 8, 4, new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e"), 3, 12, new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DireTeamId",
                table: "Games",
                column: "DireTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RadiantTeamId",
                table: "Games",
                column: "RadiantTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDetails_PlayerId",
                table: "PlayerDetails",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_GameId",
                table: "PlayerStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_HeroPlayedId",
                table: "PlayerStats",
                column: "HeroPlayedId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_PlayerId",
                table: "PlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_TeamId",
                table: "PlayerStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamsId",
                table: "PlayerTeams",
                column: "TeamsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDetails");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "PlayerTeams");

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
