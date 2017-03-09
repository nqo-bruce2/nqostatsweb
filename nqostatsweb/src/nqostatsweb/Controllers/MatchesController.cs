using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nqostatsweb.Data;
using nqostatsweb.Models;
using nqostatsweb.Models.MatchesViewModels;

namespace nqostatsweb.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var matches = await _context.Match.ToListAsync();
            var  listOfMatchesToDisplay = new List<MatchViewModel>();
            foreach (var match in matches)
            {
                var matchToDisplay = new MatchViewModel();
                matchToDisplay.Id = match.Id;
                matchToDisplay.MapName = match.MapName;
                matchToDisplay.MatchType = match.MatchType;
                var blah = Convert.ToDateTime(match.Date).ToString("ddd M/d/yyyy 'at' H:mm:ss CST");
                matchToDisplay.Date = blah;
                listOfMatchesToDisplay.Add(matchToDisplay);
            }
            listOfMatchesToDisplay.Reverse();
            return View(listOfMatchesToDisplay);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.Include(m1 => m1.Teams).SingleOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            var listOfTeamsToDisplay = new List<MatchTeamsViewModel>();
            foreach (var team in match.Teams)
            {
                var teamToDisplay = new MatchTeamsViewModel();
                teamToDisplay.Id = team.Id;
                teamToDisplay.MatchId = team.MatchId;
                teamToDisplay.TeamColor = team.TeamColor;
                teamToDisplay.TeamVerdict = team.TeamVerdict;
                teamToDisplay.TeamTotalFrags = team.TeamTotalFrags;
                teamToDisplay.TeamTotalQuads = team.TeamTotalQuads;
                teamToDisplay.TeamTotalPents = team.TeamTotalPents;
                teamToDisplay.TeamTotalEyes = team.TeamTotalEyes;
                teamToDisplay.TeamTotalRL = team.TeamTotalRL;
                teamToDisplay.TeamTotalLG = team.TeamTotalLG;
                teamToDisplay.TeamTotalGL = team.TeamTotalGL;
                teamToDisplay.TeamTotalSNG = team.TeamTotalSNG;
                teamToDisplay.TeamTotalNG = team.TeamTotalNG;
                teamToDisplay.TeamTotalMH = team.TeamTotalMH;
                teamToDisplay.TeamTotalRA = team.TeamTotalRA;
                teamToDisplay.TeamTotalYA = team.TeamTotalYA;
                teamToDisplay.TeamTotalGA = team.TeamTotalGA;
                teamToDisplay.TeamPlusRLPack = team.TeamPlusRLPack;
                teamToDisplay.TeamMinusRLPack = team.TeamMinusRLPack;
                teamToDisplay.TeamControlPercentage = (float)team.TeamControlPercentage*100;
                listOfTeamsToDisplay.Add(teamToDisplay);                
    }
            return View(listOfTeamsToDisplay);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,MapName,MatchId,MatchText,MatchType")] Matches match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.SingleOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,MapName,MatchId,MatchText,MatchType")] Matches match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.SingleOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.SingleOrDefaultAsync(m => m.Id == id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
