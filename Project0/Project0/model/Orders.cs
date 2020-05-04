using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{
    public partial class Orders
    {
        public Orders()
        {
            Orderlist = new HashSet<Orderlist>();
        }

        public int OrderId { get; set; }
        public int customerId { get; set; }
        public double Total { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public virtual Customers User { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
    }
}
