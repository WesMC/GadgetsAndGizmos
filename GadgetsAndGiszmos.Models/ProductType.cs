using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GadgetsAndGizmos.Models
{
    public class ProductType
    {
        [Key, Column("ProductTypeId")]
        public int Id { get; set; }

        [MaxLength(65)]
        [Required]
        public string SubType { get; set; }

        [MaxLength(65), AllowNull]
        public string SubType1 { get; set; }

        [MaxLength(65), AllowNull]
        public string SubType2 { get; set; }

        [MaxLength(65), AllowNull]
        public string SubType3 { get; set; }

    }
}
