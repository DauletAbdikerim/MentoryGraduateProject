using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
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
        private ApplicationContext _db;

        public BookRepository(ApplicationContext applicationContext) 
        {
            _db = applicationContext;
        }
        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
