using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySolution.Api.Data;
using LibrarySolution.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySolution.Api.Controllers
{
    [Route("/api/books/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("allbooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpGet("getbook/{bookId:int}")]
        public IActionResult GetBook(int bookId)
        {
            if (bookId.Equals(null) || bookId == 0)
            {
                return BadRequest();
            }
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { bookIsbn = book.Isbn });
        }

        [HttpPut("update/{bookId:int}")]
        public IActionResult UpdateBook(int bookId, [FromBody] Book book)
        {
            if (bookId.Equals(null) || bookId == 0)
            {
                return BadRequest();
            }
            var bookToUpdate = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bookToUpdate.BookDescription = book.BookDescription;
                bookToUpdate.BookTitle = book.BookTitle;
                bookToUpdate.DateOfPublication = book.DateOfPublication;
                _context.Books.Update(bookToUpdate);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteBook(int bookId)
        {
            if (bookId.Equals(null) || bookId == 0)
            {
                return BadRequest();
            }
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}