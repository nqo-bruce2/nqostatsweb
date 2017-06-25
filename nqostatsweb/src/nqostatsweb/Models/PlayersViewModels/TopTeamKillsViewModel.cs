using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopTeamKillsViewModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public float TeamKill { get; set; }
        public int MatchesPlayed { get; set; }
    }
}
