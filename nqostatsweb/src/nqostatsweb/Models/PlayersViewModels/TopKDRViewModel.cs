using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopKDRViewModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal KDR { get; set; }
        //public int MatchesPlayed { get; set; }

        public TopKDRViewModel()
        {

        }
    }
}
