using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BWI.JAN20.WEB.Models;

namespace BWI.JAN20.WEB.Controllers
{
    public class StudentsBookEnrollmentModelsController : Controller
    {
        private readonly BWIJAN20WEBContext _context;

        public StudentsBookEnrollmentModelsController(BWIJAN20WEBContext context)
        {
            _context = context;
        }

        // GET: StudentsBookEnrollmentModels
        public async Task<IActionResult> Index()
        {
            var bWIJAN20WEBContext = _context.StudentsBookEnrollmentModel.Include(s => s.Book).Include(s => s.Student);
            return View(await bWIJAN20WEBContext.ToListAsync());
        }

        // GET: StudentsBookEnrollmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentsBookEnrollmentModel == null)
            {
                return NotFound();
            }

            var studentsBookEnrollmentModel = await _context.StudentsBookEnrollmentModel
                .Include(s => s.Book)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsBookEnrollmentModel == null)
            {
                return NotFound();
            }

            return View(studentsBookEnrollmentModel);
        }

        // GET: StudentsBookEnrollmentModels/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.BookModel, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "Id", "Name");
            return View();
        }

        // POST: StudentsBookEnrollmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,StudentId")] StudentsBookEnrollmentModel studentsBookEnrollmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsBookEnrollmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.BookModel, "Id", "Name", studentsBookEnrollmentModel.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "Id", "Name", studentsBookEnrollmentModel.StudentId);
            return View(studentsBookEnrollmentModel);
        }

        // GET: StudentsBookEnrollmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentsBookEnrollmentModel == null)
            {
                return NotFound();
            }

            var studentsBookEnrollmentModel = await _context.StudentsBookEnrollmentModel.FindAsync(id);
            if (studentsBookEnrollmentModel == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.BookModel, "Id", "Id", studentsBookEnrollmentModel.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "Id", "Email", studentsBookEnrollmentModel.StudentId);
            return View(studentsBookEnrollmentModel);
        }

        // POST: StudentsBookEnrollmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,StudentId")] StudentsBookEnrollmentModel studentsBookEnrollmentModel)
        {
            if (id != studentsBookEnrollmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsBookEnrollmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsBookEnrollmentModelExists(studentsBookEnrollmentModel.Id))
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
            ViewData["BookId"] = new SelectList(_context.BookModel, "Id", "Id", studentsBookEnrollmentModel.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "Id", "Email", studentsBookEnrollmentModel.StudentId);
            return View(studentsBookEnrollmentModel);
        }

        // GET: StudentsBookEnrollmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentsBookEnrollmentModel == null)
            {
                return NotFound();
            }

            var studentsBookEnrollmentModel = await _context.StudentsBookEnrollmentModel
                .Include(s => s.Book)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsBookEnrollmentModel == null)
            {
                return NotFound();
            }

            return View(studentsBookEnrollmentModel);
        }

        // POST: StudentsBookEnrollmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentsBookEnrollmentModel == null)
            {
                return Problem("Entity set 'BWIJAN20WEBContext.StudentsBookEnrollmentModel'  is null.");
            }
            var studentsBookEnrollmentModel = await _context.StudentsBookEnrollmentModel.FindAsync(id);
            if (studentsBookEnrollmentModel != null)
            {
                _context.StudentsBookEnrollmentModel.Remove(studentsBookEnrollmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsBookEnrollmentModelExists(int id)
        {
          return (_context.StudentsBookEnrollmentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
