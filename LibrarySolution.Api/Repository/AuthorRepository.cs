using LibrarySolution.Api.Data;
using System.Collections.Generic;
using LibrarySolution.Api.Models;
using LibrarySolution.Api.Data.Interfaces;
using System.Linq; 

namespace LibrarySolution.Api.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public Authors CreateAuthor(Authors author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public bool DeleteAuthor(Authors author)
        {
            _context.Authors.Remove(author);
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public List<Authors> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Authors GetAuthor(int authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public Authors UpdateAuthor(Authors author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }
    }
}