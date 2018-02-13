using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetFinder.Models
{
    public class AnimalType
    {
        [Key]
        public int AnimalTypeID { get; set; }
        public string Species { get; set; }
    }
}