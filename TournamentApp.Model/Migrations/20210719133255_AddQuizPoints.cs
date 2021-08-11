using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentApp.Model.Migrations
{
    public partial class AddQuizPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Rounds_LoserNodeId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Rounds_NodeSubRoundId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Rounds_PreviousRoundId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Rounds_WinnerNodeId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Tournaments_TournamentId",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_LoserNodeId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_NodeSubRoundId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_PreviousRoundId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_WinnerNodeId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "LoserNodeId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "NodeSubRoundId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "PreviousRoundId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "WinnerNodeId",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Rounds",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_TournamentId",
                table: "Rounds",
                newName: "IX_Rounds_QuizId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxRoundScore",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuizOwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_QuizOwnerId",
                        column: x => x.QuizOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundUserPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    QuizRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundUserPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundUserPoints_Rounds_QuizRoundId",
                        column: x => x.QuizRoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuizOwnerId",
                table: "Quizzes",
                column: "QuizOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundUserPoints_QuizRoundId",
                table: "RoundUserPoints",
                column: "QuizRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Quizzes_QuizId",
                table: "Rounds",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Quizzes_QuizId",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "RoundUserPoints");

            migrationBuilder.DropColumn(
                name: "MaxRoundScore",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Rounds",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_QuizId",
                table: "Rounds",
                newName: "IX_Rounds_TournamentId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoserNodeId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeSubRoundId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousRoundId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinnerNodeId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMatchPlayed = table.Column<bool>(type: "bit", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    ScorePlayer1 = table.Column<int>(type: "int", nullable: false),
                    ScorePlayer2 = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

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
                name: "IX_Rounds_WinnerNodeId",
                table: "Rounds",
                column: "WinnerNodeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Rounds_LoserNodeId",
                table: "Rounds",
                column: "LoserNodeId",
                principalTable: "Rounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Rounds_NodeSubRoundId",
                table: "Rounds",
                column: "NodeSubRoundId",
                principalTable: "Rounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Rounds_PreviousRoundId",
                table: "Rounds",
                column: "PreviousRoundId",
                principalTable: "Rounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Rounds_WinnerNodeId",
                table: "Rounds",
                column: "WinnerNodeId",
                principalTable: "Rounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Tournaments_TournamentId",
                table: "Rounds",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
