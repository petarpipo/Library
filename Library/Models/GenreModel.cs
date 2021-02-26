using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class GenreModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<BookModel> Books { get; set; }
        public string PhotoUrl { get; set; }

        public GenreModel()
        {
            Books = new List<BookModel>();
        }
    }
}