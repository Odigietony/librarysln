using Microsoft.AspNetCore.Mvc;
using LibrarySolution.Api.Models;
using LibrarySolution.Api.Data.Interfaces;
using LibrarySolution.Api.ViewModels.AuthorsVm;

namespace LibrarySolution.Api.Controllers
{
    [Route("/api/author/")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authoRepo;
        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authoRepo = authorRepo;
        }

        [HttpGet("allauthors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authoRepo.GetAllAuthors());
        }

        [HttpGet("getauthor/{authorId:int}")]
        public IActionResult GetAuthor(int authorId)
        {
            var author = _authoRepo.GetAuthor(authorId);
            if(author == null) return NotFound();
            return Ok(author); 
        }

        [HttpPost("add-author")]
        public IActionResult Create([FromBody] CreateAuthorVm model)
        {
            if(!ModelState.IsValid) return BadRequest();
            var author = new Authors()
            {
                AuthorName = model.AuthorName,
                BriefDescription = model.BriefDescription
            };
            _authoRepo.CreateAuthor(author);
            return CreatedAtAction(nameof(GetAuthor), new { authorId = author.Id }, model);
        }

        [HttpPut("update-author/{authorId:int}")]
        public IActionResult Update(int authorId, [FromBody] UpdateAuthorVm model)
        {
            var author = _authoRepo.GetAuthor(authorId);
            if(author == null) return NotFound();
            author.AuthorName = model.AuthorName;
            author.BriefDescription = model.BriefDescription;
            _authoRepo.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("delete-author/authorId:int")]
        public IActionResult Delete(int authorId)
        {
            var author = _authoRepo.GetAuthor(authorId);
            if(author == null) return NotFound();
            if(_authoRepo.DeleteAuthor(author)) return NoContent();
            ModelState.AddModelError("", "Error: Could not delete record.");
            return StatusCode(500, ModelState);
        }
    }
}