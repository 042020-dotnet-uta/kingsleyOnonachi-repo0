using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj0.Dal
{
    class StoreDal
    {
        public StoreDal()
        {
           
        }

        private readonly ProductDal product = new ProductDal();
        private readonly DefaultStoreDal defaultStore = new DefaultStoreDal();
        private readonly OrderDal order = new OrderDal();
        /// <summary>
        /// Shows the address of a given store
        /// by query the database and extracting the store informations
        /// </summary>
        /// <param name="storeId"></param>
        public void ShowStoreAddress(project0Context context, int storeId)
        {
            var stores = from store1 in context.Store
                               where store1.StoreId == storeId
                               select store1;


            //going the the list of store
            foreach (Store store in stores)
            {
                Console.WriteLine($"{store.StoreId} {store.StreetAddress}");
                Console.WriteLine($"{store.CityAddress} {store.StateAddress}");
                Console.WriteLine($"{store.CountryAddress}");
            }
            
        }
        
        /// <summary>
        /// List all the store location customers
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <returns name="customers"></returns>
      public ICollection<Customers>listCustomerAStoreHas(project0Context context ,int storeId)
        {
            ICollection<Customers> customers = defaultStore.GetAllCustomerOfStore(context, storeId);
            return customers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public void DisplayOrderHistoryofStore(project0Context context, int storeId)
        {   
           
            List<int> customerId = defaultStore.GetCustomersByStoreId(context, storeId);
            foreach(int cus in customerId) {
                var inOrder = context.Orders.FirstOrDefault(c => c.UserId == cus);
                Console.WriteLine($"OrderId: {inOrder.OrderId}\tCustomerId: {inOrder.UserId}\tTotal Amount: {inOrder.Total}\tDate: {inOrder.OrderDate}");

            }
            
        }

        /// <summary>
        ///Given the store id this method will display all the product in stock
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        public void DisplayProductsInStore(project0Context context, int storeId)
        {
            product.DisplayStoreProducts(context, storeId);
        }

    }
}
