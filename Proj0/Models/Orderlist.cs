using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Orderlist
    {
        private int orderlistId;
        private int orderId;
        private int productId;
        private int quantity;
        private DateTimeOffset orderDate;
     
        public DateTimeOffset OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }


        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }


        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }


        public int OrderlistId
        {
            get { return orderlistId; }
            set { orderlistId = value; }
        }

        public virtual Orders Order { get; set; }
    }
}
