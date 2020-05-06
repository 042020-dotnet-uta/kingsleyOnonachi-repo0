using System;
using System.Collections.Generic;

namespace Proj0.Models
{
    public partial class Orderlist
    {
        public int OrderlistId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Inventory Product { get; set; }
    }
}
