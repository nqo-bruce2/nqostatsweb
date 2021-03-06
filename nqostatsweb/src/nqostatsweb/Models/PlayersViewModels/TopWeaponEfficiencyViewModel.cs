﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopWeaponEfficiencyViewModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float PlayerTotalWeaponEfficiency { get; set; }
    }
}
