using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using nqostatsweb.Data;
using nqostatsweb.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace nqostatsweb.ViewComponents
{
    public class TopWinPercentViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopWinPercentViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<TopWinPercentViewModel>> GetItemsAsync()
        {
            // call top 5 win percent
            var items = _context.Set<TopWinPercentViewModel>().FromSql("call Top5WinPercent('2017-03-21','2017-06-21')");
            items.ToListAsync();
            items = items.Take(5);

            return items.ToListAsync();
        }
    }
}
