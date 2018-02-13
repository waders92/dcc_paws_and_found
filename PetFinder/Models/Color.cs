using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetFinder.Models
{
    public class Color
    {
        [Key]
        [Display(Name = "Color")]
        public int ColorID { get; set; }
        public string Hue { get; set; }
    }
}