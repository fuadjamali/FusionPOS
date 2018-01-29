using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionPosModels.EntityModels
{
    public class PurchaseReceive
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(11)]
        public string No { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long SupplierId { get; set; }
        public virtual Party Supplier { get; set; }

        [Required]
        public virtual Outlet Outlet { get; set; }
        public long OutletId { get; set; }
        public virtual Employee PurchaseBy { get; set; }
        [Required]
        public long PurchaseById { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<PurchaseReceiveItems> Items { get; set; }

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
