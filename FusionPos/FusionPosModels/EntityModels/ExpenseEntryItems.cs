using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionPosModels.EntityModels;

namespace FusionPosModels
{
    public class ExpenseEntryItems
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long ExpenseItemId { get; set; }
        public ExpenseItem ExpenseItem { get; set; }
        public string Description { get; set; }

        [Required]
        public int Qty { get; set; }
        [Required]
        public double Amount { get; set; }

        public long ExpenseEntryId { get; set; }
        public ExpenseEntry ExpenseEntry { get; set; }
        

        public double LineTotal()
        {
            return Qty * Amount;
        }
    }
}
