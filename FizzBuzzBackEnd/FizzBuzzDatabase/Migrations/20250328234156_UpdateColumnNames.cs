using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FizzBuzzDatabase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameRules_Games_GameId",
                table: "GameRules");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_Games_GameId",
                table: "GameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_Players_PlayerId",
                table: "GameSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameSessions",
                table: "GameSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRules",
                table: "GameRules");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "GameSessions",
                newName: "GameSession");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "GameRules",
                newName: "GameRule");

            migrationBuilder.RenameIndex(
                name: "IX_Players_Name",
                table: "Player",
                newName: "IX_Player_Name");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessions_PlayerId",
                table: "GameSession",
                newName: "IX_GameSession_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessions_GameId",
                table: "GameSession",
                newName: "IX_GameSession_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Name",
                table: "Game",
                newName: "IX_Game_Name");

            migrationBuilder.RenameIndex(
                name: "IX_GameRules_GameId",
                table: "GameRule",
                newName: "IX_GameRule_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameSession",
                table: "GameSession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRule",
                table: "GameRule",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Author", "Name" },
                values: new object[,]
                {
                    { 1, "", "FooBooLoo" },
                    { 2, "", "FizzBuzz" }
                });

            migrationBuilder.InsertData(
                table: "GameRule",
                columns: new[] { "Id", "Divisor", "GameId", "Replacement" },
                values: new object[,]
                {
                    { 1, 7, 0, "Foo" },
                    { 2, 13, 0, "Boo" },
                    { 3, 103, 0, "Loo" }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alice" },
                    { 2, "Bob" }
                });

            migrationBuilder.InsertData(
                table: "GameSession",
                columns: new[] { "Id", "CorrectAnswers", "Duration", "EndTime", "GameId", "IncorrectAnswers", "PlayerId", "StartTime" },
                values: new object[,]
                {
                    { 1, 3, 60, null, 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 45, null, 2, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GameRule_Game_GameId",
                table: "GameRule",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Game_GameId",
                table: "GameSession",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Player_PlayerId",
                table: "GameSession",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameRule_Game_GameId",
                table: "GameRule");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Game_GameId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Player_PlayerId",
                table: "GameSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameSession",
                table: "GameSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRule",
                table: "GameRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DeleteData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GameSession",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameSession",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "GameSession",
                newName: "GameSessions");

            migrationBuilder.RenameTable(
                name: "GameRule",
                newName: "GameRules");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Name",
                table: "Players",
                newName: "IX_Players_Name");

            migrationBuilder.RenameIndex(
                name: "IX_GameSession_PlayerId",
                table: "GameSessions",
                newName: "IX_GameSessions_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSession_GameId",
                table: "GameSessions",
                newName: "IX_GameSessions_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameRule_GameId",
                table: "GameRules",
                newName: "IX_GameRules_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_Name",
                table: "Games",
                newName: "IX_Games_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameSessions",
                table: "GameSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRules",
                table: "GameRules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameRules_Games_GameId",
                table: "GameRules",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_Games_GameId",
                table: "GameSessions",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_Players_PlayerId",
                table: "GameSessions",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
