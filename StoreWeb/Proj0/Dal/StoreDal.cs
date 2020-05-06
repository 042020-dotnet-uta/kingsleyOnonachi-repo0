using Proj0.Models;
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

        /// <summary>
        /// Shows the address of a given store
        /// by query the database and extracting the store informations
        /// </summary>
        /// <param name="storeId"></param>
        public void showStoreAddress(project0Context context, int storeId)
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
        
      /*public ICollection<Customers>listCustomerAStoreHas(int storeId)
        {
            ICollection<Customers> customers = new List<Customers>();

        }
        public ICollection<Orders>displayTotalOrder(int storeId)
        {

        }
        public int qtyProductInStore(int storeId, int productId)
        {

        }*/

    }
}
