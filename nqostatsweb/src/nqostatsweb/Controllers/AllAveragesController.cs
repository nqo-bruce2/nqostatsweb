using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nqostatsweb.Data;
using nqostatsweb.Models.AllAveragesViewModels;
using Microsoft.EntityFrameworkCore;

namespace nqostatsweb.Controllers
{
    public class AllAveragesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AllAveragesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            // call top 5 win percent
            var items = _context.Set<AllAveragesViewModel>().FromSql("call AverageStats('2017-03-21','2017-06-21')");
            await items.ToListAsync();
            var temp = items.Where(x => Convert.ToInt32(x.MatchesPlayed) >= 1);
            
            foreach (var player in temp )
            {
                if (player.Name.StartsWith("["))
                    player.Name = "\'" + player.Name + "\'";

                //player.AverageFrags = ConvertEfficiency(player.AverageFrags);
                //player.AverageDeaths = ConvertEfficiency(player.AverageDeaths);
                player.AverageEff = ConvertEfficiency(player.AverageEff);
                //player.AverageQuads = ConvertEfficiency(player.AverageQuads);
                //player.AvgFragsPerQuad = ConvertEfficiency(player.AvgFragsPerQuad);
                //player.AverageSelfKills = ConvertEfficiency(player.AverageSelfKills);
                //player.AverageTeamKills = ConvertEfficiency(player.AverageTeamKills);
                player.AverageSelfDmg = ConvertEfficiency(player.AverageSelfDmg);
                player.AverageTeamDmg = ConvertEfficiency(player.AverageTeamDmg);
                player.SGeff = ConvertEfficiency(player.SGeff);
                player.NailEff = ConvertEfficiency(player.NailEff);
                player.RLEff = ConvertEfficiency(player.RLEff);
                player.LGEff = ConvertEfficiency(player.LGEff);
                player.WinPercentage = ConvertEfficiency(player.WinPercentage);
                //player.KDR = ConvertEfficiency(player.KDR);
            }


            //items = items.Take(5);
            //return View(items);
            return View(temp);
        }

        private string ConvertEfficiency(string valueToconvert)
        {
            if (!String.IsNullOrEmpty(valueToconvert))
                return Math.Round(Convert.ToDecimal(valueToconvert) * 100, 2) + "%";
            return "N/A";
        }
    }
}