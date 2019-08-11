using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AD4.Models
{
    [Table("Items")]
    public class Items
    {
        [Key]
        public int Code { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double price { get; set; }

    }
}