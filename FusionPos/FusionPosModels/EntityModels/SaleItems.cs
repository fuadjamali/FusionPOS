using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionPosModels.EntityModels
{
    public class SaleItems
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public double Qty { get; set; }
        [Required]
        public double Price { get; set; }

        public double LineTotal()
        {
            return Qty*Price;
        }
    }
}
