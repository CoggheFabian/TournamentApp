using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentApp.Model.Migrations
{
    public partial class RemovePlayerKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player1Key",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2Key",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Player1Key",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Player2Key",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
