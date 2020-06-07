using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibrarySolution.Api.Models
{
    [Table("authors")]
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string BriefDescription { get; set; }
    }
}