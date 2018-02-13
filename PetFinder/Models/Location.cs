using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetFinder.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string ZipCode { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }
    }
}