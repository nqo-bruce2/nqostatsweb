using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.TotalStatsViewModels
{
    public class TotalStatsViewModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Games { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string Frags { get; set; }
        public string Deaths { get; set; }
        public string Quads { get; set; }
        public string TKs { get; set; }
        public string SelfKill { get; set; }
        public string DroppedPaks { get; set; }
        public string QuadFrags { get; set; }
        public string OneVOnes { get; set; }
        public string TwoVTwos { get; set; }
        public string ThreeVThrees { get; set; }
        public string FourVFours { get; set; }
    }
}
