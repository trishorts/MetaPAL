using MetaPAL.Data;
using MetaPAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MetaPAL.Controllers
{
    public class ReposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReposController
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem("Title", "Title"),
                new SelectListItem("Description", "Description"),
            };

            ViewBag.RepoFeatures = selectListItems;
            if (_context.Repos == null)
                return Problem("Entity set 'ApplicationDbContext.Repos'  is null.");
            return View(await _context.Repos.ToListAsync());
        }

        // GET: ReposController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Repos/Create
        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem("Select Repo Features", ""),
                new SelectListItem("Title", "Title"),
                new SelectListItem("Description", "Description"),
            };

            ViewBag.RepoFeatures = selectListItems;
            return View();
        }

        // POST: Repo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Repo repo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repo);
        }

        // GET: Repo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Repos == null)
            {
                return NotFound();
            }

            var repo = await _context.Repos.FindAsync(id);
            if (repo == null)
            {
                return NotFound();
            }
            return View(repo);
        }

        // POST: Repos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Repo repo)
        {
            if (id != repo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepoExists(repo.Id))
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
            return View(repo);
        }

        // GET: Repos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repos == null)
            {
                return NotFound();
            }

            var repo = await _context.Repos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repo == null)
            {
                return NotFound();
            }

            return View(repo);
        }

        // POST: Repos/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Repos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Repo'  is null.");
            }
            var repo = await _context.Repos.FindAsync(id);
            if (repo != null)
            {
                _context.Repos.Remove(repo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepoExists(int id)
        {
            return (_context.Repos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
