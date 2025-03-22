using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotaNerf.Migrations
{
    /// <inheritdoc />
    public partial class DBrestructurexD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("07f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("18f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("29f99d5e-9f4b-4c8a-9f9e-9f4b2c8a9f9e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("30f09d5e-0f4b-4c8a-9f0e-0f4b3c8a9f0e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("41f19d5e-1f4b-4c8a-9f1e-1f4b4c8a9f1e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("52f29d5e-2f4b-4c8a-9f2e-2f4b5c8a9f2e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("63f39d5e-3f4b-4c8a-9f3e-3f4b6c8a9f3e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"));

            migrationBuilder.DropColumn(
                name: "GameDuration",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "GameResult",
                table: "GameStats");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameStats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
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
                        name: "FK_Games_Team_DireTeamId",
                        column: x => x.DireTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Team_RadiantTeamId",
                        column: x => x.RadiantTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.GamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"),
                column: "TeamId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b2f29d5e-2d4b-4c8a-9c2e-2d4b5c8a9c2e"),
                column: "TeamId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"),
                column: "TeamId",
                value: null);

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), 0 },
                    { new Guid("b4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), 1 },
                    { new Guid("b5f11c36-5e5d-471e-9537-0d1f8765c15c"), 1 },
                    { new Guid("b642cc17-3c5b-4ad7-8830-9c9bb2107750"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DireTeamId", "RadiantTeamId", "WinningTeam" },
                values: new object[,]
                {
                    { new Guid("77f79d5e-7f7b-478a-977f-7f7b078a977f"), new Guid("b4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), new Guid("a4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), 1 },
                    { new Guid("d4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), new Guid("b4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), new Guid("a4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_GameId",
                table: "GameStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DireTeamId",
                table: "Games",
                column: "DireTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RadiantTeamId",
                table: "Games",
                column: "RadiantTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayersId",
                table: "PlayerGames",
                column: "PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStats_Games_GameId",
                table: "GameStats",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Team_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStats_Games_GameId",
                table: "GameStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Team_TeamId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_GameStats_GameId",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameStats");

            migrationBuilder.AddColumn<int>(
                name: "GameDuration",
                table: "GameStats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameResult",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "GamesLost", "GamesWon", "Name", "TotalGames", "Winrate" },
                values: new object[,]
                {
                    { new Guid("07f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), 9, 10, "Rumen", 19, 52.0 },
                    { new Guid("18f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), 9, 6, "Bobur Kurva", 15, 40.0 },
                    { new Guid("29f99d5e-9f4b-4c8a-9f9e-9f4b2c8a9f9e"), 10, 6, "Dj Misho", 16, 38.0 },
                    { new Guid("30f09d5e-0f4b-4c8a-9f0e-0f4b3c8a9f0e"), 12, 7, "Kuncho", 19, 37.0 },
                    { new Guid("41f19d5e-1f4b-4c8a-9f1e-1f4b4c8a9f1e"), 4, 1, "Sofiqneca", 5, 20.0 },
                    { new Guid("52f29d5e-2f4b-4c8a-9f2e-2f4b5c8a9f2e"), 6, 2, "Vaneto", 8, 25.0 },
                    { new Guid("63f39d5e-3f4b-4c8a-9f3e-3f4b6c8a9f3e"), 6, 0, "Mario", 6, 0.0 },
                    { new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"), 6, 9, "Kriskata", 15, 60.0 },
                    { new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), 7, 10, "Marto", 17, 59.0 },
                    { new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), 7, 7, "Steli", 14, 50.0 }
                });
        }
    }
}
