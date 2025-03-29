using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotaNerf.Migrations
{
    /// <inheritdoc />
    public partial class MorePlayerEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "PlayerDetailsId" },
                values: new object[,]
                {
                    { new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e"), "Retar Dio (Roskata)", new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e") },
                    { new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), "Panic", new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e") },
                    { new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), "The Joker", new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e") },
                    { new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), "Baba Yaga", new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e") },
                    { new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), "Danitthedog", new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e") }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "GamesLost", "GamesWon", "PlayerId", "TotalGames", "Winrate" },
                values: new object[] { new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e"), 3, 5, new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e"), 8, 62.0 });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "PlayerId", "Winrate" },
                values: new object[,]
                {
                    { new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), 0.0 },
                    { new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), 0.0 },
                    { new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), 0.0 },
                    { new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e"));

            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"));

            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"));

            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"));

            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("74f49d5e-4f4b-4c8a-9f4e-4f4b7c8a9f4e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("85f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("96f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a7f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b8f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"));
        }
    }
}
