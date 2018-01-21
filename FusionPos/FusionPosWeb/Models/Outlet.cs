using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FusionPosWeb.Models
{
    public class Outlet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Address mus be entere")]
        public string Address { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

    }
}