using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class AddBookToStore
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
        public List<BookModel> Books { get; set; }
        public AddBookToStore()
        {
            Books = new List<BookModel>();
        }

    }
}