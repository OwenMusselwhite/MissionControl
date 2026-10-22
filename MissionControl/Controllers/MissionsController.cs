
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionControl.Models;
using MissionControl.Data;

public class MissionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public MissionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MISSIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Missions.ToListAsync());
    }

    // GET: MISSIONS/Details/5
    public async Task<IActionResult> Details(int? missionid)
    {
        if (missionid == null)
        {
            return NotFound();
        }

        var mission = await _context.Missions
            .FirstOrDefaultAsync(m => m.MissionId == missionid);
        if (mission == null)
        {
            return NotFound();
        }

        return View(mission);
    }

    // GET: MISSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MISSIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MissionId,MissionName,DestinationPlanet,LaunchDate,MissionStatus,CrewMembers")] Mission mission)
    {
        if (ModelState.IsValid)
        {
            _context.Add(mission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(mission);
    }

    // GET: MISSIONS/Edit/5
    public async Task<IActionResult> Edit(int? missionid)
    {
        if (missionid == null)
        {
            return NotFound();
        }

        var mission = await _context.Missions.FindAsync(missionid);
        if (mission == null)
        {
            return NotFound();
        }
        return View(mission);
    }

    // POST: MISSIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? missionid, [Bind("MissionId,MissionName,DestinationPlanet,LaunchDate,MissionStatus,CrewMembers")] Mission mission)
    {
        if (missionid != mission.MissionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(mission);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(mission.MissionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(mission);
    }

    // GET: MISSIONS/Delete/5
    public async Task<IActionResult> Delete(int? missionid)
    {
        if (missionid == null)
        {
            return NotFound();
        }

        var mission = await _context.Missions
            .FirstOrDefaultAsync(m => m.MissionId == missionid);
        if (mission == null)
        {
            return NotFound();
        }

        return View(mission);
    }

    // POST: MISSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? missionid)
    {
        var mission = await _context.Missions.FindAsync(missionid);
        if (mission != null)
        {
            _context.Missions.Remove(mission);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MissionExists(int? missionid)
    {
        return _context.Missions.Any(e => e.MissionId == missionid);
    }
}
