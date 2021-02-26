using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class StoreModel
    {
        [Key]
        public int id { get; set; }
        public virtual List<BookModel> Books {get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string  City { get; set; }
        public StoreModel()
        {
            Books = new List<BookModel>();
        }
        public string  PhotoUrl { get; set; }

    }
}