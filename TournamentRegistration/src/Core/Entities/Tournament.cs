using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<UserTournament> UserTournaments { get; set; } = new List<UserTournament>();
    }
}
