﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FusionPosModels.EntityModels
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public bool IsRoot { get; set; }
        public int? ParentId { get; set; }
        public virtual ExpenseCategory Parent { get; set; }

        public virtual List<ExpenseCategory> Childs { get; set; }
    }
}