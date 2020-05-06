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
    class ProductDal
    {
        public static int productId;
        private project0Context _context;
        public ProductDal()
        {
            using project0Context context = new project0Context();
            _context = context;
        }
        public void displayStoreProducts(int storeId, int productId)
        {
             var products = _context.Inventory
                .Where(p => p.ProductId == productId && p.StoreId == storeId)
                .OrderBy(p=> p.Name);

            foreach(Inventory product in products)
            {
                Console.WriteLine("Product Id\t\tName\t\tDescription\t\tPrice per Unit\t");
                Console.WriteLine($"{product.ProductId}\t\t{product.Name}\t\t{product.Description}\t\t{product.ListPrice}");
            }
        }

        public void addNewProduct()
        {

            productId++;
            Inventory product = new Inventory();
            
            //get the product name
            Console.WriteLine("Enter the product name");
            product.Name = Console.ReadLine();
            //get the product storeId
            Console.WriteLine("Enter the storeId ");
            string iD = Console.ReadLine();
            if (!int.TryParse(iD, out int qty))
            {
                // Parsing failed, handle the error however you like
            }
            product.Quantity = qty;

            //get the descrition of the product
            Console.WriteLine("Enter the product description");
            product.Description = Console.ReadLine();

            //get the product list price
            Console.WriteLine("Enter the price ");
            string pricestr = Console.ReadLine();
            if (!int.TryParse(iD, out int price))
            {
                // Parsing failed, handle the error however you like
            }
            product.ListPrice = price;

            _context.Inventory.Add(product);
            _context.SaveChanges();

            //update the context
            using project0Context context = new project0Context();
            _context = context;
        }

        public int getQuantityOfProduct(int productid, int storeId)
        {
            int qty = new int();
            var product = _context.Inventory
                .Where(p => p.ProductId == productid && p.StoreId == storeId)
                .FirstOrDefault();
            if(product is Inventory)
            {
                if(product.Quantity is null)
                {
                    qty = 0;
                    return qty;
                }
                qty = (int)product.Quantity;
            }
            else
            {
                return -1;
            }

            return qty;
        }

        public void addToExistProduct(int productId, int storeId, int quantity)
        {
            int qty = getQuantityOfProduct(productId, storeId);
            if(qty == -1)
            {
                addNewProduct();
            }
            else
            {
                var product = _context.Inventory
               .Where(p => p.ProductId == productId && p.StoreId == storeId)
               .FirstOrDefault();

                if (product is Inventory)
                {
                    product.Quantity = quantity;
                    _context.Inventory.Add(product);
                    _context.SaveChanges();

                    using project0Context context = new project0Context();
                    _context = context;
                }
            }
        }
    }
}
