using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FusionPosWeb.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }

        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }

    }
}