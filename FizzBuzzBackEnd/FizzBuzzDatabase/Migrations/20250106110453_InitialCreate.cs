using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FizzBuzzDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Divisor = table.Column<int>(type: "int", nullable: false),
                    Replacement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Questions = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    IncorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSession_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameRule",
                columns: new[] { "Id", "Divisor", "Replacement" },
                values: new object[,]
                {
                    { 1, 7, "Foo" },
                    { 2, 13, "Boo" },
                    { 3, 103, "Loo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_PlayerID",
                table: "GameSession",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRule");

            migrationBuilder.DropTable(
                name: "GameSession");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
