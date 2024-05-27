using GraduateProject.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(Guid bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid bookId);
    }
}
