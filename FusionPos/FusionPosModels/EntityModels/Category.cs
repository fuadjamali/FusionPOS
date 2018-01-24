using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "Name can be in maximum 100 letters")]
        public string Name { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "Code can be maximum 20 letters")]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsRoot { get; set; }

        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }

        public byte[] Image { get; set; }

        public List<Category> ChildCategories { get; set; }

        public List<Item> Items { get; set; }
    }
}