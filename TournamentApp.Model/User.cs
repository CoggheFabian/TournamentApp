namespace TournamentApp.Model
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
    }
}