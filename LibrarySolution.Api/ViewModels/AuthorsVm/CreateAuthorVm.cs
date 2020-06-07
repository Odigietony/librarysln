using System.ComponentModel.DataAnnotations;
namespace LibrarySolution.Api.ViewModels.AuthorsVm
{
    public class CreateAuthorVm
    {
        [Required]
        [StringLength(30)]
        public string AuthorName { get; set; }
        [Required]
        [StringLength(400)]
        public string BriefDescription { get; set; }
    }
}