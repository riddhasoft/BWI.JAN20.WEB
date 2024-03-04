using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BWI.JAN20.WEB.Models;
using BWI.JAN20.WEB.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BWI.JAN20.WEB.Controllers
{
    [Authorize(Roles = "user")]
    public class BookModelsController : Controller
    {

        readonly IBookService _bookService;

        public BookModelsController(IBookService bookService)
        {
            //_bookService = new BookService(context);
            //_bookService.AnotherPublicMethod();
            _bookService = bookService;
        }

        // GET: BookModels
        public async Task<IActionResult> Index()
        {
            //throw new Exception("My Exeption");
            var books = _bookService.GetBooks();
            return View(books);
        }

        // GET: BookModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var book = _bookService.GetBook(id ?? 0);

            return View(book);
        }

        // GET: BookModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,Year,Rate,Publication")] BookModel bookModel)
        {

            if (ModelState.IsValid)
            {
                _bookService.SaveBook(bookModel);
                return RedirectToAction(nameof(Index));
            }
            return View(bookModel);
        }

        // GET: BookModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookModel = _bookService.GetBook(id ?? 0);
            if (bookModel == null)
            {
                return NotFound();
            }
            return View(bookModel);
        }

        // POST: BookModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,Year,Rate,Publication")] BookModel bookModel)
        {
            if (id != bookModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.UpdateBook(bookModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookModelExists(bookModel.Id))
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
            return View(bookModel);
        }

        // GET: BookModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookModel = _bookService.GetBook(id ?? 0);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // POST: BookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(int id)
        {
            return _bookService.GetBook(id) != null;
        }
    }
}
