using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models
{
    public class MatchTeamStats
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string TeamColor { get; set; }
        public string TeamVerdict { get; set; }
        public int TeamTotalFrags { get; set; }
        public int TeamTotalQuads { get; set; }
        public int TeamTotalPents { get; set; }
        public int TeamTotalEyes { get; set; }
        public int TeamTotalRL { get; set; }
        public int TeamTotalLG { get; set; }
        public int TeamTotalGL { get; set; }
        public int TeamTotalSNG { get; set; }
        public int TeamTotalNG { get; set; }
        public int TeamTotalMH { get; set; }
        public int TeamTotalRA { get; set; }
        public int TeamTotalYA { get; set; }
        public int TeamTotalGA { get; set; }
        public string TeamPlusRLPack { get; set; }
        public string TeamMinusRLPack { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? TeamControlPercentage { get; set; }

        [ForeignKey("MatchId")]
        public Matches Match { get; set; }
    }
}
