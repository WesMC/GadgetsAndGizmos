using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GadgetsAndGizmos.Models
{
    public class Category
    {
        /// <summary>
        /// Category.Id in App is CategoryId in Database
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Display(Name="Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [ForeignKey("ParentId")]
        public virtual Category Parent {get; set;}
        public int? ParentId {get; set;}

        public virtual IEnumerable<Category> SubCategoies { get; set; } 
    }
}
