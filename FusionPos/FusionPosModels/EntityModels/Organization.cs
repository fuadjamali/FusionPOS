using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Name must be within 100 letters")]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(50)]
        public string ContactNo { get; set; }
        public byte[] LogoImage { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
    }
}