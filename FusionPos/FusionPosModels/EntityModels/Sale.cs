using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FusionPosModels.EntityModels
{
    public class Sale
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(11)]
        public string No { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        [Required]
        public long SoldById { get; set; }
        public virtual Employee SoldBy { get; set; }

        [Required]
        public long CustomerId { get; set; }
        public virtual Party Customer { get; set; }

        
        public double? Vat { get; set; }
        public double? Discount { get; set; }
        public virtual ICollection<SaleItems> Items { get; set; }
        public double TotalAmount()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.LineTotal();
            }
            return total;
        }
    }
}
