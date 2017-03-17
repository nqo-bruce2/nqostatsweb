using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopWinsViewModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int PlayerTotalNumberOfWins { get; set; }
    }
}
