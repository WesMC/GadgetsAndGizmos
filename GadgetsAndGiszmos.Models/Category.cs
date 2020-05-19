using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GadgetsAndGizmos.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name="Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
