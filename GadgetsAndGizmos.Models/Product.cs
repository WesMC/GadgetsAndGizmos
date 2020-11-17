using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GadgetsAndGizmos.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(1,100000)]
        public double Price { get; set; }
        [Range(1, 100000)]
        public double MSRP { get; set; }
        [Range(1, 100000)]
        public double Cost { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public string Manufacturer { get; set; }
        public string Distributor { get; set; }

        public double Weight { get; set; }
        public double VolumeX {get; set;}
        public double VolumeY {get; set;}
        public double VolumeZ { get; set; }

        public enum WeightSystem { 
            lbs = 0,
            kg = 1
        }

        public enum VolumeSystem {
            inch = 0,
            cm = 1
        }

        
    }
}