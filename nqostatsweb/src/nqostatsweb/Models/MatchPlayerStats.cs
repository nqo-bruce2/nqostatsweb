﻿using System;
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
        public string QuadEfficiency { get; set; }
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
        public string BulletEfficiency { get; set; }
        public string NailsEfficiency { get; set; }
        public string RocketEfficiency { get; set; }
        public string LightningEfficiency { get; set; }
        public string TotalEfficiency { get; set; }
        // begin bad stats
        public int DroppedPaks { get; set; }
        public string SelfDamage { get; set; }
        public string TeamDamage { get; set; }

        [ForeignKey("PlayerId")]
        public Players Player { get; set; }
    }
}
