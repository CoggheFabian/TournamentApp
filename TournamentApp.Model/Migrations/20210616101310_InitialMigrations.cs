using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentApp.Model.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousRoundId = table.Column<int>(type: "int", nullable: true),
                    WinnerNodeId = table.Column<int>(type: "int", nullable: true),
                    LoserNodeId = table.Column<int>(type: "int", nullable: true),
                    NodeSubRoundId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Rounds_LoserNodeId",
                        column: x => x.LoserNodeId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Rounds_NodeSubRoundId",
                        column: x => x.NodeSubRoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Rounds_PreviousRoundId",
                        column: x => x.PreviousRoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Rounds_WinnerNodeId",
                        column: x => x.WinnerNodeId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    ScorePlayer1 = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    ScorePlayer2 = table.Column<int>(type: "int", nullable: false),
                    IsMatchPlayed = table.Column<bool>(type: "bit", nullable: false),
                    RoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Users_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Users_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RoundId",
                table: "Matches",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_LoserNodeId",
                table: "Rounds",
                column: "LoserNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_NodeSubRoundId",
                table: "Rounds",
                column: "NodeSubRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_PreviousRoundId",
                table: "Rounds",
                column: "PreviousRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_TournamentId",
                table: "Rounds",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnerNodeId",
                table: "Rounds",
                column: "WinnerNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
