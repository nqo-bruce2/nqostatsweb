using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopWinStreakViewModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Streak { get; set; }
        public int MatchesPlayed { get; set; }

        public TopWinStreakViewModel()
        {

        }
    }
}
