using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "Code must be within 20 letters")]
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