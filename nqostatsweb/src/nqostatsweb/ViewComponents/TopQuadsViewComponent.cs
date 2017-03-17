using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Data;
using nqostatsweb.Models;
using nqostatsweb.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.ViewComponents
{
    public class TopQuadsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopQuadsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<TopQuadsViewModel>> GetItemsAsync()
        {
            var items = from T1 in _context.Players
                        join T2 in _context.MatchPlayerStats on T1.Id equals T2.PlayerId
                        group new
                        {
                            T1,
                            T2
                        }
                        by new
                        {
                            T1.Id,
                            T1.Name
                        }into g
                        select new TopQuadsViewModel
                        {
                            PlayerId = g.Key.Id,
                            Name = g.Key.Name,
                            PlayerTotalNumberOfQuads = g.Sum(T2 => T2.T2.NumberOfQuads)
                        };


            items = items.OrderByDescending(x => x.PlayerTotalNumberOfQuads);
            items.ToListAsync();
            items = items.Take(5);

            return items.ToListAsync();
        }
    }
}   
