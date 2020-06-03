using System.Collections.Generic;
using LibrarySolution.Api.Models; 
namespace LibrarySolution.Api.Data.Interfaces
{
    public interface IBookRepository
    {
        //@Todo: clean this up later.
        Book GetBook(int bookId);
        List<Book> GetAllBooks();
        Book Ceate(Book book);
        Book Update(Book bookId);
        bool Delete(Book book);
    }
}