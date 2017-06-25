using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nqostatsweb.Data;
using nqostatsweb.Models.AllAveragesViewModels;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Models.TotalStatsViewModels;

namespace nqostatsweb.Controllers
{
    public class TotalStatsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TotalStatsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            // call top 5 win percent
            var items = _context.Set<TotalStatsViewModel>().FromSql("call TotalStats('2017-03-21','2017-06-21')");
            await items.ToListAsync();
            var temp = items.Where(x => Convert.ToInt32(x.Games) >= 1);
            
            foreach (var player in temp )
            {
                if (player.Name.StartsWith("["))
                    player.Name = "\'" + player.Name + "\'";
            }


            //items = items.Take(5);
            //return View(items);
            return View(temp);
        }
    }
}