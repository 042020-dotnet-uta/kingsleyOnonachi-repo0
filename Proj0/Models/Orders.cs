using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Orders
    {
        public Orders()
        {
            Orderlist = new HashSet<Orderlist>();
        }
        private int orderId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        private DateTimeOffset orderDate;

        public DateTimeOffset OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public virtual Customers User { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
    }
}
