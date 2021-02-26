using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  Author { get; set; }
        public string  PhotoUrl { get; set; }
        public string About { get; set; }
        [Required]
        [Range(0,200)]
        public float Price { get; set; }
        public string Published { get; set; }
    }
}