using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
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

        [Required(ErrorMessage = "Address must be entered")]

        public string Address { get; set; }
        [Required]

        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

    }
}