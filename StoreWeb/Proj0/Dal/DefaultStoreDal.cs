using Proj0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Here the record of customers and their perfer store location 
/// </summary>
namespace Proj0.Dal
{

    class DefaultStoreDal
    {
        

        public DefaultStoreDal()
        {
            

        }

        public List<Customers> getAllCustomerOfStore(project0Context context, int storeId)
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


    }
}
