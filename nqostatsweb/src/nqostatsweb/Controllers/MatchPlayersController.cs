using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Data;
using nqostatsweb.Models;

namespace nqostatsweb.Controllers
{
    public class MatchPlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchPlayersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MatchPlayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Players.ToListAsync());
        }

        // GET: MatchPlayers
        public async Task<IActionResult> TeamPlayers(int? matchId, string teamColor)
        {
            var playas = (await _context.MatchPlayerStats.Include(p => p.Player).Where(x => x.TeamColor.Equals(teamColor) && x.MatchId.Equals(matchId)).ToListAsync());
            return View(playas);
        }

        // GET: MatchPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players.SingleOrDefaultAsync(m => m.Id == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // GET: MatchPlayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IpAddress,Name,Password,UserName")] Players players)
        {
            if (ModelState.IsValid)
            {
                _context.Add(players);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(players);
        }

        // GET: MatchPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players.SingleOrDefaultAsync(m => m.Id == id);
            if (players == null)
            {
                return NotFound();
            }
            return View(players);
        }

        // POST: MatchPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IpAddress,Name,Password,UserName")] Players players)
        {
            if (id != players.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(players);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayersExists(players.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(players);
        }

        // GET: MatchPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players.SingleOrDefaultAsync(m => m.Id == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // POST: MatchPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var players = await _context.Players.SingleOrDefaultAsync(m => m.Id == id);
            _context.Players.Remove(players);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}