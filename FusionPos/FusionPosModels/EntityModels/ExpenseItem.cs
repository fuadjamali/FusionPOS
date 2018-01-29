using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class ExpenseItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ExpenseCategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        
    }
}