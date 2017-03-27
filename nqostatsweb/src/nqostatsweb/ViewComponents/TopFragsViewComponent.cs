using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Data;
using nqostatsweb.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.ViewComponents
{
    public class TopFragsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopFragsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<TopFragsViewModel>> GetItemsAsync()
        {
            var startDate = new DateTime(2017, 03, 21);
            var endDate = new DateTime(2017, 06, 21);

            var items = from T1 in _context.Players
                        join T2 in _context.MatchPlayerStats on T1.Id equals T2.PlayerId
                        join T3 in _context.Match on T2.MatchId equals T3.Id
                        where T3.Date >= startDate && T3.Date < endDate
                        group new
                        {
                            T1,
                            T2,
                        }
                        by new
                        {
                            T1.Id,
                            T1.Name
                        } into g
                        select new TopFragsViewModel
                        {
                            Name = g.Key.Name,
                            PlayerTotalNumberOfFrags = g.Sum(T2 => T2.T2.NumOfFrags)
                        };

            items = items.OrderByDescending(x => x.PlayerTotalNumberOfFrags);
            items.ToListAsync();
            items = items.Take(5);

            return items.ToListAsync();
        }
    }
}
