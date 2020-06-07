using System.Collections.Generic; 
using LibrarySolution.Api.Models;
using LibrarySolution.Api.Data;
using LibrarySolution.Api.Data.Interfaces;
using System.Linq;

namespace LibrarySolution.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public Book Ceate(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public bool Delete(Book book)
        {
            _context.Books.Remove(book);
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public Book Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }
    }
}