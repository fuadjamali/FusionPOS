using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FusionPosModels.EntityModels;

namespace FusionPosModels
{
    public  class ExpenseEntry
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }
        [Required]
        public long EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ICollection<ExpenseEntryItems> ExpenseItems { get; set; }

        public double TotalAmount()
        {
            double total = 0;
            foreach (var expenseItem in ExpenseItems)
            {
                total += expenseItem.LineTotal();
            }
            return total;
        }


    }
}
