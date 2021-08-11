using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentApp.Model.Migrations
{
    public partial class AddBoolCheckingIfQuizIsFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsQuizFinished",
                table: "Quizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsQuizFinished",
                table: "Quizzes");
        }
    }
}
