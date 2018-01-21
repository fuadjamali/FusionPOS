using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace FusionPosWeb.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}