using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.MatchesViewModels
{
    public class MatchDisplay
    {
        public int Id { get; set; }
        public string MatchType { get; set; }
        public string MapName { get; set; }
        //public DateTime Date { get; set; }
        public string Date { get; set; }

        public List<MatchTeamStats> Teams { get; set; }
    }
}
