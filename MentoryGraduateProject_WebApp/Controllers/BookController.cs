using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MentoryGraduateProject_WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _bookRepository.GetBooks();
            return View(books);
        }

        public IActionResult Details(Guid id)
        {
            Book book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Create(object book)
        {
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(Guid id)
        {
            Book book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookRepository.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(Guid id)
        {
            Book book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookRepository.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}