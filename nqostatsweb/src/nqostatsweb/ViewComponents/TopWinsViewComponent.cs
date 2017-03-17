﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Data;
using nqostatsweb.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.ViewComponents
{
    public class TopWinsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopWinsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<TopWinsViewModel>> GetItemsAsync()
        {
            var items = from T1 in _context.Players
                        join T2 in _context.MatchPlayerStats on T1.Id equals T2.PlayerId
                        join T3 in _context.MatchTeamStats on T2.MatchId equals T3.MatchId
                        where T2.TeamColor == T3.TeamColor
                        && T3.TeamVerdict == "win"
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
                        select new TopWinsViewModel
                        {
                            Name = g.Key.Name,
                            PlayerTotalNumberOfWins = g.Count()
                        };

            items = items.OrderByDescending(x => x.PlayerTotalNumberOfWins);
            items.ToListAsync();
            items = items.Take(5);

            return items.ToListAsync();
        }
    }
}
