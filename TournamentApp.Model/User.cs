namespace TournamentApp.Model
{
    public class User : EntityBase
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
    }
}