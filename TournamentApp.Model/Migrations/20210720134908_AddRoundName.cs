using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentApp.Model.Migrations
{
    public partial class AddRoundName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Users_QuizOwnerId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_QuizOwnerId",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "RoundName",
                table: "Rounds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizOwnerId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundName",
                table: "Rounds");

            migrationBuilder.AlterColumn<int>(
                name: "QuizOwnerId",
                table: "Quizzes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuizOwnerId",
                table: "Quizzes",
                column: "QuizOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Users_QuizOwnerId",
                table: "Quizzes",
                column: "QuizOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
