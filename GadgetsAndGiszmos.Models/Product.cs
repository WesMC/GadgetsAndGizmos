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
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string Distributor { get; set; }
        public double Weight { get; set; }
        public double VolumeX {get; set;}
        public double VolumeY {get; set;}
        public double VolumeZ { get; set; }

    }
}