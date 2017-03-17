using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.Models.PlayersViewModels
{
    public class TopFragsViewModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int PlayerTotalNumberOfFrags { get; set; }
    }
}
