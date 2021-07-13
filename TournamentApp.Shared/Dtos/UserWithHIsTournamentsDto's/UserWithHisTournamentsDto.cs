using System.Collections.Generic;
using System.Linq;

namespace TournamentApp.Shared.Dtos
{
    public class UserWithHisTournamentsDto
    {
        public Dictionary<int,string> Tournaments { get; set; }
        public GetUserDto User { get; set; }
    }
}