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
        [Display(Name = "Color")]
        public string Hue { get; set; }
    }
}