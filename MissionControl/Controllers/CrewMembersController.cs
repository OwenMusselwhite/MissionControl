
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionControl.Models;
using MissionControl.Data;

public class CrewMembersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CrewMembersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CREWMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CrewMembers.ToListAsync());
    }

    // GET: CREWMEMBERS/Details/5
    public async Task<IActionResult> Details(int? crewmemberid)
    {
        if (crewmemberid == null)
        {
            return NotFound();
        }

        var crewmember = await _context.CrewMembers
            .FirstOrDefaultAsync(m => m.CrewMemberId == crewmemberid);
        if (crewmember == null)
        {
            return NotFound();
        }

        return View(crewmember);
    }

    // GET: CREWMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CREWMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CrewMemberId,FirstName,LastName,Role,ExperienceYears,MissionId,Mission")] CrewMember crewmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(crewmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(crewmember);
    }

    // GET: CREWMEMBERS/Edit/5
    public async Task<IActionResult> Edit(int? crewmemberid)
    {
        if (crewmemberid == null)
        {
            return NotFound();
        }

        var crewmember = await _context.CrewMembers.FindAsync(crewmemberid);
        if (crewmember == null)
        {
            return NotFound();
        }
        return View(crewmember);
    }

    // POST: CREWMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? crewmemberid, [Bind("CrewMemberId,FirstName,LastName,Role,ExperienceYears,MissionId,Mission")] CrewMember crewmember)
    {
        if (crewmemberid != crewmember.CrewMemberId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(crewmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrewMemberExists(crewmember.CrewMemberId))
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
        return View(crewmember);
    }

    // GET: CREWMEMBERS/Delete/5
    public async Task<IActionResult> Delete(int? crewmemberid)
    {
        if (crewmemberid == null)
        {
            return NotFound();
        }

        var crewmember = await _context.CrewMembers
            .FirstOrDefaultAsync(m => m.CrewMemberId == crewmemberid);
        if (crewmember == null)
        {
            return NotFound();
        }

        return View(crewmember);
    }

    // POST: CREWMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? crewmemberid)
    {
        var crewmember = await _context.CrewMembers.FindAsync(crewmemberid);
        if (crewmember != null)
        {
            _context.CrewMembers.Remove(crewmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CrewMemberExists(int? crewmemberid)
    {
        return _context.CrewMembers.Any(e => e.CrewMemberId == crewmemberid);
    }
}
