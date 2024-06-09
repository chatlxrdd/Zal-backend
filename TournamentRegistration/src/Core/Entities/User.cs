using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<UserTournament> UserTournaments { get; set; } = new List<UserTournament>();
    }
}
