using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFHomework.DataAccessLayer;
using EFHomework.Models;

namespace EFHomework.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryRepository _repository;

        public BooksController(LibraryRepository repository)
        {

            this._repository = repository;
        }

        // GET: Books
        public IActionResult Index(string val)
        {
            var books = new List<Book>();
            if (!String.IsNullOrEmpty(val))
            {
                books = _repository.LookupBook(val).ToList();
                return View(books);
            }
            books = _repository.GetAllBooks().ToList();
            return View(books);
        }

        // GET: Books/Details/5
         public IActionResult Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

            var book = _repository.GetBook(id);
            BookAuthorViewModel vm = new BookAuthorViewModel()
            {
                Book = book,
                Author = _repository.GetAuthor(book.AuthorId)
            };

             return View(vm);
         }

         // GET: Books/Create
         public IActionResult Create()
         {

             return View();
         }

         // POST: Books/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Create([Bind("Name,Id,Count,Description,AuthorId")] Book book)
         {
             if (ModelState.IsValid)
             {
                _repository.AddBook(book);
                return RedirectToAction(nameof(Index));
             }
          
            return View(book);
         }

         // GET: Books/Edit/5
         public IActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var book = _repository.GetBook(id);
             
            if (book == null)
             {
                 return NotFound();
             }
             return View(book);
         }

         // POST: Books/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Edit(int id, [Bind("Name,Id,Count,Description,AuthorId")] Book book)
         {
             if (id != book.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                    _repository.UpdateBook(book);
                     
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!BookExists(book.Id))
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
             return View(book);
         }

         // GET: Books/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

            var book = _repository.GetBook(id);
             if (book == null)
             {
                 return NotFound();
             }

             return View(book);
         }

         // POST: Books/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
            var book = _repository.GetBook(id);
            _repository.DeleteBook(id);
             
             return RedirectToAction(nameof(Index));
         }

         private bool BookExists(int id)
         {
             return _repository.GetAllBooks().Any(e => e.Id == id);
         }
    }
}
