using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MetaPAL.Data;
using MetaPAL.DataOperations;
using MetaPAL.Models;
using Microsoft.AspNetCore.Authorization;
using Readers;

namespace MetaPAL.Controllers
{
    public class SpectrumMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpectrumMatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpectrumMatches
        public async Task<IActionResult> Index()
        {
            // TEMPORARY: remove all spectrum matches from database
            //Task.Run(() => DataOperations.DataOperations.RemoveAll<SpectrumMatch>(_context)).Wait();
            

            if (_context.SpectrumMatch == null)
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            return View(await _context.SpectrumMatch.ToListAsync());
        }

        // GET: UploadSpectralMatchesForm
        public async Task<IActionResult> UploadSpectralMatchesForm()
        {
            return _context.SpectrumMatch != null ?
                View() :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }

        // GET: UploadSpectrumMatches
        public async Task<IActionResult> UploadSpectralMatches(string PsmPath)
        {
            if (_context.SpectrumMatch == null)
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            try
            {
                foreach (var psm in SpectrumMatchTsvReader.ReadTsv(PsmPath, out _))
                {
                    _context.Add(SpectrumMatch.FromSpectrumMatchTsv(psm));
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.SpectrumMatch != null ?
                View() :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }

        // GET: ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.SpectrumMatch != null ?
                View(await _context.SpectrumMatch.Where(b=>b.BaseSequence.Contains(SearchPhrase)).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }
        // GET: SpectrumMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }

            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpectrumMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchedFragmentIons,FullSequence,Ms2ScanNumber,FileNameWithoutExtension,PrecursorScanNum,PrecursorCharge,PrecursorMz,PrecursorMass,RetentionTime,Score,SpectrumMatchCount,Accession,SpectralAngle,QValue,PEP,PEP_QValue,TotalIonCurrent,DeltaScore,Notch,BaseSeq,EssentialSeq,AmbiguityLevel,MissedCleavage,MonoisotopicMass,MassDiffDa,MassDiffPpm,Name,GeneName,OrganismName,IntersectingSequenceVariations,IdentifiedSequenceVariations,SpliceSites,Description,StartAndEndResiduesInParentSequence,PreviousResidue,NextResidue,DecoyContamTarget,QValueNotch")] SpectrumMatch spectrumMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectrumMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch.FindAsync(id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }
            return View(spectrumMatch);
        }

        // POST: SpectrumMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchedFragmentIons,FullSequence,Ms2ScanNumber,FileNameWithoutExtension,PrecursorScanNum,PrecursorCharge,PrecursorMz,PrecursorMass,RetentionTime,Score,SpectrumMatchCount,Accession,SpectralAngle,QValue,PEP,PEP_QValue,TotalIonCurrent,DeltaScore,Notch,BaseSeq,EssentialSeq,AmbiguityLevel,MissedCleavage,MonoisotopicMass,MassDiffDa,MassDiffPpm,Name,GeneName,OrganismName,IntersectingSequenceVariations,IdentifiedSequenceVariations,SpliceSites,Description,StartAndEndResiduesInParentSequence,PreviousResidue,NextResidue,DecoyContamTarget,QValueNotch")] SpectrumMatch spectrumMatch)
        {
            if (id != spectrumMatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectrumMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectrumMatchExists(spectrumMatch.Id))
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
            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }

            return View(spectrumMatch);
        }

        // POST: SpectrumMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SpectrumMatch == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            }
            var spectrumMatch = await _context.SpectrumMatch.FindAsync(id);
            if (spectrumMatch != null)
            {
                _context.SpectrumMatch.Remove(spectrumMatch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectrumMatchExists(int id)
        {
          return (_context.SpectrumMatch?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
