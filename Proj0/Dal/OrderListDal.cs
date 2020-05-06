using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proj0.Dal
{
    class OrderListDal
    {
        public OrderListDal() { }

        

        public void DispalyOrderlist(project0Context context, int orderId)
        {
            ///Displaying the list of an order by the orderId by querrying the orderlist table
            ///Input: Dbcontext and int 
            ///Output: None
            ///
            if(orderId <= 0)
            {
                Console.WriteLine("Please input an order id: ");
                string o = Console.ReadLine();
                int.TryParse(o, out orderId);
                 
            }

            var orders = from orderlist in context.Orderlist
                         where orderlist.OrderId == orderId
                         select orderlist;
            if(orders == null)
            {
                Console.WriteLine("No such order was found:");
            }
            else 
            { 
                 foreach(Orderlist orders1 in orders)
                 {
                    
                    var inventory = context.Inventory.FirstOrDefault(i => i.InventoryId == orders1.ProductId);
                    double itemPrice = inventory.ListPrice;
                    string name = inventory.Name;
                    Console.WriteLine($"productId: {orders1.ProductId}\tqty: {orders1.Quantity}\tproduct name: {name}\t price: {itemPrice}\torder Date: {orders1.OrderDate}");
                 }
            }

            
        }

        public Orderlist MakeOrder(int productId, int orderId, int quantity)
        {
            Orderlist order = new Orderlist()
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity,
                OrderDate = DateTimeOffset.UtcNow
            };

            return order;
        }
        

    }
}
