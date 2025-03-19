using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotaNerf.Migrations
{
    /// <inheritdoc />
    public partial class AddingHerosEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroPlayed",
                table: "GameStats");

            migrationBuilder.AddColumn<int>(
                name: "HeroPlayedId",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_HeroPlayedId",
                table: "GameStats",
                column: "HeroPlayedId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStats_Heroes_HeroPlayedId",
                table: "GameStats",
                column: "HeroPlayedId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStats_Heroes_HeroPlayedId",
                table: "GameStats");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_GameStats_HeroPlayedId",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "HeroPlayedId",
                table: "GameStats");

            migrationBuilder.AddColumn<string>(
                name: "HeroPlayed",
                table: "GameStats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
