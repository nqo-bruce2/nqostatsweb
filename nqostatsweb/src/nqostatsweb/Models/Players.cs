
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace nqostatsweb.Models
{
    public class Players
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<MatchPlayerStats> PlayerStats { get; set; }
    }
}
