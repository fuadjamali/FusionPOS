using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsRoot { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public List<Category> ChildCategories { get; set; } 
        public byte[] Image { get; set; }


    }
}