using Proj0.store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

/// <summary>
/// Here the record of customers and their perfer store location 
/// </summary>
namespace Proj0.Dal
{

    class DefaultStoreDal
    {

        //Menu menu = new Menu();
        public DefaultStoreDal()
        {
            

        }

        /// <summary>
        /// get all the customers in a store
        /// input: store id and Dbcontext
        /// output: list of all customer of a given store
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <returns name="storeCustomers"></returns>
        public List<Customers> GetAllCustomerOfStore(project0Context context, int storeId)
        {
            List<Customers> storeCustomers = new List<Customers>();
            var custId = context.Defaultstore
                .Where(ds => ds.StoreId == storeId);
            List<int> cutid = context.Defaultstore
                .Where(c => c.StoreId == storeId)
                .Select(c => c.UserId)
                .ToList();
            foreach (var cuid in cutid) {
                var customers = context.Customers
                    .Where(c => c.CustomerId == cuid)
                    .FirstOrDefault();
                storeCustomers.Add(customers);
            }

            return storeCustomers;
        }
        /// <summary>
        /// Return the number of customers a store location has
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <returns name="customer count"></returns>
        public int TotalOfStoreCustomers(project0Context context, int storeId = 1)
        {
            var custId = context.Defaultstore
                .Where(ds => ds.StoreId == storeId);
            List<int> cutid = context.Defaultstore
                .Where(c => c.StoreId == storeId)
                .Select(c => c.UserId)
                .ToList();
            return cutid.Count;
        }

        public List<int> GetCustomersByStoreId(project0Context context, int storeId = 1)
        {
            var customers = context.Defaultstore
                .Where(ds => ds.StoreId == storeId);
            List<int> customerId = context.Defaultstore
                .Where(c => c.StoreId == storeId)
                .Select(c => c.UserId)
                .ToList();

            return customerId;
        }
        /// <summary>
        /// Get the customer's default store location of a customer
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerId"></param>
        /// <returns name="storeId"></returns>
        public int GetCustomerDefaultStore(project0Context context, int customerId)
        {
            int storeId;
            try
            {
                var storeID = context.Defaultstore.FirstOrDefault(s => s.UserId == customerId);
                storeId = storeID.StoreId;
            }catch(ArgumentNullException e)
            {
                Console.WriteLine("CustomerDal has no default store",e);
                storeId = 0;
                //menu.BackToMenu();
            }
            if(storeId <= 0)
            {
                Console.WriteLine("CustomerDal has no default store");
                storeId = 0;
                //menu.BackToMenu();
            }

            return storeId;
        }



    }
}
