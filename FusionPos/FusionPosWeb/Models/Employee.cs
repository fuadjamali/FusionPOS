using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace FusionPosWeb.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        public int ReferenceId { get; set; }
        public virtual Employee Reference { get; set; }

        [Required]
        public string EmergencyContactNo { get; set; }
        [Required]
        public string Nid { get; set; }
        [Required]
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
    }

    
}