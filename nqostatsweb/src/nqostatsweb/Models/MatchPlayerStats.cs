using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models
{
    public class MatchPlayerStats
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        // begin skill stats
        public string TeamColor { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? KillEfficiency { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? WeaponEfficiency { get; set; }
        // begin quad stats
        public int NumberOfQuads { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? QuadEfficiency { get; set; }
        public int NumQuadEnemyKills { get; set; }
        public int NumQuadSelfKills { get; set; }
        public int NumQuadTeamKills { get; set; }
        // begin kill stats
        public int NumOfFrags { get; set; }
        public int NumOfEnemyKills { get; set; }
        public int NumOfSelfKills { get; set; }
        public int NumOfTeamKills { get; set; }
        public int NumOfDeaths { get; set; }
        // begin efficiency stats
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? BulletEfficiency { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? NailsEfficiency { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? RocketEfficiency { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? LightningEfficiency { get; set; }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal? TotalEfficiency { get; set; }
        // begin bad stats
        public int DroppedPaks { get; set; }
        public decimal? SelfDamage { get; set; }
        public decimal? TeamDamage { get; set; }

        [ForeignKey("PlayerId")]
        public Players Player { get; set; }
    }
}
