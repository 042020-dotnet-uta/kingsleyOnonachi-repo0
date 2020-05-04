using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{

    public partial class Orderlist
    {   
        [Key]
        public int OrderlistId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int storeId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
        public virtual Store Store { get; set; }

    }
}
