using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FizzBuzzDatabase.Migrations
{
    /// <inheritdoc />
    public partial class CreateController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Player_PlayerID",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "GameSession",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSession_PlayerID",
                table: "GameSession",
                newName: "IX_GameSession_PlayerId");

            migrationBuilder.RenameColumn(
                name: "Replacement",
                table: "GameRule",
                newName: "Word");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "GameSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "GameSession",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "GameSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "GameSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameRule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinRange = table.Column<int>(type: "int", nullable: false),
                    MaxRange = table.Column<int>(type: "int", nullable: false),
                    Timer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "GameRule",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_GameId",
                table: "GameSession",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_PlayerId1",
                table: "GameSession",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameRule_GameId",
                table: "GameRule",
                column: "GameId");

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

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Player_PlayerId1",
                table: "GameSession");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_GameId",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_PlayerId1",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_GameRule_GameId",
                table: "GameRule");

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
                name: "EndTime",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameRule");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "GameSession",
                newName: "PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_GameSession_PlayerId",
                table: "GameSession",
                newName: "IX_GameSession_PlayerID");

            migrationBuilder.RenameColumn(
                name: "Word",
                table: "GameRule",
                newName: "Replacement");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Player_PlayerID",
                table: "GameSession",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
