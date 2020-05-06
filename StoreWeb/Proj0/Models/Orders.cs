using System;
using System.Collections.Generic;

namespace Proj0.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderlist = new HashSet<Orderlist>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public virtual Customers User { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
    }
}
