namespace TournamentApp.Shared.Dtos
{
    public class CreatedUserDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}