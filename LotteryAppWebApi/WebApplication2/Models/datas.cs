using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication2.Models
{
    public partial class datas
    {
        [Column(TypeName = "int(10)")]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        [Column(TypeName = "smallint(10)")]
        public short quantity { get; set; }
        [Column(TypeName = "smallint(10)")]
        public short value { get; set; }
        [Required]
        [StringLength(1000)]
        public string picture { get; set; }
        [StringLength(2000)]
        public string logo { get; set; }
    }
}
