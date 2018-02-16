using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetFinder.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }


        [Column(TypeName = "datetime2")]
        [Display(Name ="Date")]
        public DateTime? PostDate { get; set; }

        public string Title { get; set; }

        [MaxLength(509)]
        public string Message { get; set; }

        public string Image { get; set; }

        public bool isReunited { get; set; }
        public bool isPetUser { get; set; }

        public bool isPetFinder { get; set; }

        public string UserID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public Location Location { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeID { get; set; }
        public AnimalType AnimalType { get; set; }

        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public Color Color { get; set; }
    }
}