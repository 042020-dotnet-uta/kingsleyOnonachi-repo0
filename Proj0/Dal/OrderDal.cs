
using Org.BouncyCastle.Bcpg;
using Proj0.store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj0.Dal
{
    class OrderDal
    {
        private readonly Menu menu = new Menu();
        readonly OrderListDal orderitem = new OrderListDal();
        private readonly ProductDal products = new ProductDal();
        private readonly DefaultStoreDal ds = new DefaultStoreDal();
        private readonly CustomerDal CustomerDal = new CustomerDal();
        private double price;

        public double ProductPrice
        {
            get { return price; }
            set { price = value; }
        }

        public void DisplayCustomerOrder(project0Context context, int orderId, int customerId)
        {
            if (orderId <= 0 || customerId <= 0)
            {
                Console.WriteLine("No Such order or Customer in our Database");
                menu.BackToMenu();
            }
            Console.WriteLine($"Order Id: {orderId}\tcustomer Id: {customerId}\t");
            orderitem.DispalyOrderlist(context, orderId);
            menu.BackToMenu();

        }

        /// <summary>
        /// Grab the last Order Id since the order id is auto increamented
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int GetTheLastOrderId(project0Context context)
        {
               return context.Orders.Max(o => o.OrderId);
    
        }

        /// <summary>
        /// Adding item to the order list or cart
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerId"></param>
        private double sumTotal = 0.0;
        public Orderlist AddProductToOrder(project0Context context, int customerId, int orderId)
        {
            Orderlist orderlist = new Orderlist();
            Console.WriteLine("Enter Product name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter Quantity:");
            string qty = Console.ReadLine();
            int quantity;
            while (!int.TryParse(qty, out quantity))
            {
                Console.WriteLine("Wrong value was entered:");

            }
            int productId = products.GetProductIdByName(context,productName);
            int storeId = ds.GetCustomerDefaultStore(context, customerId);
            ProductPrice = products.GetPriceOfProduct(context, productId);
            if (!products.IsQuantityInStockEnough(context,  storeId, productId, quantity))
            {
                Console.WriteLine("Quantity in stock can service this order please change the quantity:");
                int quantityInStock = products.GetQuantityOfProduct(context, productId, storeId);
                Console.WriteLine($"The quantity in stock is: {quantityInStock}");
            }
            else
            {

                orderlist= orderitem.MakeOrder(productId, orderId, quantity);
                sumTotal += ProductPrice;
            }

            return orderlist;

        }

        public ICollection<Orders>GetDayOrders(project0Context context,DateTime orderDate)
        {
            var order = context.Orders
                .Where(o => o.OrderDate == orderDate)
                .ToList();
            return order;

        }
        
        public int GetCustomerIdByOrder(project0Context context, int orderId)
        {
            var customer = context.Orders.FirstOrDefault(c => c.OrderId == orderId);
            return customer.UserId;
        }

        public void PlaceOrder(project0Context context)
        {
            List<Orderlist> orderlists = new List<Orderlist>();
            int orderId = GetTheLastOrderId(context) + 1;
            Console.WriteLine("What is the customerId:");

            string cs = Console.ReadLine();
            int custId;
            if (!int.TryParse(cs, out custId))
            {
                Console.WriteLine("We don't have you in our system");

            }
            else
            {
                char stop = 'A';
                do
                {
                    orderlists.Add(AddProductToOrder(context, custId, orderId));
                    Console.WriteLine("Contnue shopping enter and letter or enter E to stop:");
                    string str = Console.ReadLine();
                    if(str != "")
                        stop = str[0];

                } while (stop != 'E');

            }

            Orders order = new Orders()
            {
                UserId = custId,
                Total = sumTotal,
                OrderDate = DateTime.Now
            };
            context.Add(order);
            context.SaveChanges();
            context.Add(orderlists);
            context.SaveChanges();
            /*foreach(Orderlist ol in orderlists)
            {
                context
            }*/
        }
        /// <summary>
        /// Show the order history of a customer
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerId"></param>
        public void DisplayCustomerHist(project0Context context, int customerId)
        {
            var customerOrder = context.Orders
                .Where(c => c.UserId == customerId)
                .ToList();
            if (!(customerOrder == null))
            {
                foreach (Orders co in customerOrder)
                {
                    Console.WriteLine($"Customer ID: {co.UserId}\tOrder ID: {co.OrderId}\tDate: {co.OrderDate}\tAmount:{co.Total}");
                }
            }
            else
            {
                Console.WriteLine("This customer hasn't order anything yet!");
            }

        }

    }
}
