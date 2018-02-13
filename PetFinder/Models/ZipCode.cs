using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetFinder.Models
{
    public class ZipCode
    {
        [Key]
        public int ZipCodeID { get; set; }

        public string Zip { get; set; }
       
    }
}