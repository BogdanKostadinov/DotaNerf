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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winrate = table.Column<double>(type: "float", nullable: false),
                    TotalGames = table.Column<int>(type: "int", nullable: false),
                    GamesWon = table.Column<int>(type: "int", nullable: false),
                    GamesLost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroPlayed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xpm = table.Column<double>(type: "float", nullable: true),
                    Gpm = table.Column<double>(type: "float", nullable: true),
                    LastHits = table.Column<int>(type: "int", nullable: true),
                    Kills = table.Column<int>(type: "int", nullable: true),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    GameDuration = table.Column<int>(type: "int", nullable: true),
                    GameResult = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), 3, 6, "dummy", 9, 67.0 },
                    { new Guid("b2f29d5e-2d4b-4c8a-9c2e-2d4b5c8a9c2e"), 3, 6, "Stoqn (kolega)", 9, 67.0 },
                    { new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), 7, 12, "Veni", 19, 63.0 },
                    { new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"), 6, 9, "Kriskata", 15, 60.0 },
                    { new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), 7, 10, "Marto", 17, 59.0 },
                    { new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), 7, 7, "Steli", 14, 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_PlayerId",
                table: "GameStats",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStats");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
