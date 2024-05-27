using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return _context.Books.Find(bookId);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBook(Guid bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
