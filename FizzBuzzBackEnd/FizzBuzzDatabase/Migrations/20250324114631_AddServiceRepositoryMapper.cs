using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FizzBuzzDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRepositoryMapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Player_PlayerId1",
                table: "GameSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameSession",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_PlayerId1",
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
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "HighScore",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "Questions",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "MaxRange",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "MinRange",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Game");

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
                name: "IX_GameSession_PlayerId",
                table: "GameSessions",
                newName: "IX_GameSessions_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSession_GameId",
                table: "GameSessions",
                newName: "IX_GameSessions_GameId");

            migrationBuilder.RenameColumn(
                name: "Word",
                table: "GameRules",
                newName: "Replacement");

            migrationBuilder.RenameIndex(
                name: "IX_GameRule_GameId",
                table: "GameRules",
                newName: "IX_GameRules_GameId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "GameSessions",
                type: "datetime2(3)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "GameSessions",
                type: "datetime2(3)",
                precision: 3,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Players_Name",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameSessions",
                table: "GameSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Name",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRules",
                table: "GameRules");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

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
                name: "IX_GameSessions_PlayerId",
                table: "GameSession",
                newName: "IX_GameSession_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessions_GameId",
                table: "GameSession",
                newName: "IX_GameSession_GameId");

            migrationBuilder.RenameColumn(
                name: "Replacement",
                table: "GameRule",
                newName: "Word");

            migrationBuilder.RenameIndex(
                name: "IX_GameRules_GameId",
                table: "GameRule",
                newName: "IX_GameRule_GameId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Player",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HighScore",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Player",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "GameSession",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(3)",
                oldPrecision: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "GameSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(3)",
                oldPrecision: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GameSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "GameSession",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Questions",
                table: "GameSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "GameSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxRange",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinRange",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Timer",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Id", "Author", "GameName", "MaxRange", "MinRange", "Timer" },
                values: new object[] { 1, "Admin", "Default Game", 100, 1, 60 });

            migrationBuilder.InsertData(
                table: "GameRule",
                columns: new[] { "Id", "Divisor", "GameId", "Word" },
                values: new object[,]
                {
                    { 1, 7, 1, "Foo" },
                    { 2, 13, 1, "Boo" },
                    { 3, 103, 1, "Loo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_PlayerId1",
                table: "GameSession",
                column: "PlayerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Player_PlayerId1",
                table: "GameSession",
                column: "PlayerId1",
                principalTable: "Player",
                principalColumn: "Id");
        }
    }
}
