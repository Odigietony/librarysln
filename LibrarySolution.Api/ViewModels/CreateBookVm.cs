using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySolution.Api.ViewModels
{
    public class CreateBookVm
    { 
        [Required]
        [MaxLength(13)]
        public string Isbn { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}