using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySolution.Api.Data.Interfaces;
using LibrarySolution.Api.Models;
using LibrarySolution.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySolution.Api.Controllers
{
    [Route("/api/books/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        [HttpGet("allbooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookRepo.GetAllBooks());
        }

        [HttpGet("getbook/{bookId:int}")]
        public IActionResult GetBook(int bookId)
        {
            if (bookId.Equals(null) || bookId == 0)
            {
                return BadRequest();
            }
            var book = _bookRepo.GetBook(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateBookVm model)
        {
            // @Todo: Clean this up later with automapper.
            if(!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            var book = new Book()
            {
                Isbn = model.Isbn,
                BookTitle = model.BookTitle,
                BookDescription = model.BookDescription,
                DateOfPublication = model.DateOfPublication
            };   
            _bookRepo.Ceate(book);
            return CreatedAtAction(nameof(GetBook), new { bookId = book.Id });
        }

        [HttpPut("update/{bookId:int}")]
        public IActionResult UpdateBook(int bookId, [FromBody] UpdateBookVm model)
        { 
            var book = _bookRepo.GetBook(model.Id);
            if (book == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // @Todo: Clean this up later with automapper.
                book.BookDescription = model.BookDescription;
                book.BookTitle = model.BookTitle;
                book.DateOfPublication = model.DateOfPublication;
                _bookRepo.Update(book); 
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{bookId:int}")]
        public IActionResult DeleteBook(int bookId)
        { 
            var book =  _bookRepo.GetBook(bookId);
            if (book == null)
            {
                return NotFound();
            }
           _bookRepo.Delete(book);
            return NoContent();
        }
    }
}