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
    public class TopTeamKillsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopTeamKillsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<TopTeamKillsViewModel>> GetItemsAsync()
        {
            // call top 5 win percent
            var items = _context.Set<TopTeamKillsViewModel>().FromSql("call HighestTKs('2017-03-21','2017-06-21')");
            items.ToListAsync();
            items = items.Take(5);
            return items.ToListAsync();
        }
    }
}
