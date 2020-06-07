using LibrarySolution.Api.Models;
using System.Collections.Generic;
namespace LibrarySolution.Api.Data.Interfaces
{
    public interface IAuthorRepository
    {
        List<Authors> GetAllAuthors();
        Authors GetAuthor(int authorId);
        Authors CreateAuthor(Authors author);
        Authors UpdateAuthor(Authors author);
        bool DeleteAuthor(Authors author);
    }
}