using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.AllAveragesViewModels
{
    public class AllAveragesViewModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int MatchesPlayed { get; set; }
        public string AverageFrags { get; set; }
        public string AverageDeaths { get; set; }
        public string AverageEff { get; set; }
        public string AverageQuads { get; set; }
        public string AvgFragsPerQuad { get; set; }
        public string AverageSelfKills { get; set; }
        public string AverageTeamKills { get; set; }
        public string AverageSelfDmg { get; set; }
        public string AverageTeamDmg { get; set; }
        public string SGeff { get; set; }
        public string NailEff { get; set; }
        public string RLEff { get; set; }
        public string LGEff { get; set; }
        public string WinPercentage { get; set; }
        public string KDR { get; set; }
    }
}
