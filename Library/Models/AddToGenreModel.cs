using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class AddToGenreModel
    {
        public int GenreId { get; set; }
        public int BookId { get; set; }
        public List<BookModel> Books { get; set; }

        public AddToGenreModel()
        {
            Books = new List<BookModel>();
        }
    }
}