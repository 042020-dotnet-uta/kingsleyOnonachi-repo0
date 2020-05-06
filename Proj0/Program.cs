using Proj0.Dal;
using System;
using System.Linq;

namespace Proj0
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDal customerDal = new CustomerDal();
            using project0Context context = new project0Context();
            {
                var products = context.Inventory
                    .ToList();

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Name} productId {product.ProductId}\n");
                }

                DefaultStoreDal def = new DefaultStoreDal();
                def.GetAllCustomerOfStore(context, 1);
                /*Customers customer = customerDal.addACustomer();
                context.Customers.Add(customer);
                context.SaveChanges();
                Console.WriteLine("Hello World!");*/
            }
            Customers disl = customerDal.GetCustomerById(context, 1);

            Console.WriteLine($"{disl.FirstName} {disl.LastName}");

        }
    }
}
