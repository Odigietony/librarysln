using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySolution.Api.Models
{
    [Table("books")]
    public class Book
    {
        [Key] 
        public int Id { get; set; }
        [MaxLength(13)]
        public string Isbn { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
