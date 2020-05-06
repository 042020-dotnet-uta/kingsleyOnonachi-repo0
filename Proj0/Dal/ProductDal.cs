using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace Proj0.Dal
{
    class ProductDal
    {
       
        public ProductDal()
        {
            
        }

        /// <summary>
        /// This method display all the products in a given store location 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        public void DisplayStoreProducts(project0Context context, int storeId)
        {
             var products = context.Inventory
                .Where(p => p.StoreId == storeId)
                .OrderBy(p=> p.Name);

            foreach(Inventory product in products)
            {
                Console.WriteLine("Product Id\t\tName\t\tDescription\t\tPrice per Unit\t");
                Console.WriteLine($"{product.ProductId}\t\t{product.Name}\t\t{product.Description}\t\t{product.ListPrice}");
            }
        }

        /// <summary>
        /// This method is use to add new product to stock of a given store location
        /// </summary>
        /// <param name="context"></param>
        public void AddNewProduct(project0Context context)
        {


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

            context.Inventory.Add(product);
            context.SaveChanges();

           
        }
        /// <summary>
        /// This is use to get the quantity of products in stock
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productid"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public int GetQuantityOfProduct(project0Context context, int productid, int storeId)
        {
            int qty = new int();
            var product = context.Inventory
                .Where(p => p.ProductId == productid && p.StoreId == storeId)
                .FirstOrDefault();
            if(product is Inventory)
            {
                if(product.Quantity <= 0)
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
        /// <summary>
        /// This is use to to add to exist product in stock
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <param name="quantity"></param>
        public void AddToExistProduct(project0Context context, int productId, int storeId, int quantity)
        {
            int qty = GetQuantityOfProduct(context,productId, storeId);
            if(qty == -1)
            {
                AddNewProduct(context);
            }
            else
            {
                var product = context.Inventory
               .Where(p => p.ProductId == productId && p.StoreId == storeId)
               .FirstOrDefault();

                if (product is Inventory)
                {
                    product.Quantity = quantity;
                    context.Inventory.Add(product);
                    context.SaveChanges();

                }
            }
        }

        /// <summary>
        /// Get the price of the product by query the inventory table with productId
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productId"></param>
        /// <returns name="ListPrice"></returns>
        public double GetPriceOfProduct(project0Context context, int productId)
        {
            double listPrice;
            if (productId <= 0)
            {
                Console.WriteLine("No such item here");
                return -1;
            }
            try
            {
                var product = context.Inventory
                    .Where(i => i.ProductId == productId)
                    .FirstOrDefault();

                listPrice = product.ListPrice;
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("No such item here", e);
                return 0;
            }

            return listPrice;

        }
        /// <summary>
        /// checking if the stock will be enough to fullfill the order size
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns name="boolean"></returns>
        public bool IsQuantityInStockEnough(project0Context context, int storeId, int productId, int request)
        {
            bool available = false;
            int qty = GetQuantityOfProduct(context, productId, storeId);
            if (qty < 1)//checking if the product is in stock
            {
                Console.WriteLine("Run Out of Stock");//
                return false;
            }
            else
            {
                var product = context.Inventory
               .Where(p => p.ProductId == productId && p.StoreId == storeId)
               .FirstOrDefault();

                if (product is Inventory)//checking that product is inventory object and if so check the quantity in stock 
                {
                    if (product.Quantity <= request)//making if what in stock can service the order
                        available = false;
                    else
                        available = true;
                }
            }
            return available;
        }

        /// <summary>
        /// Updating product quantity in stock
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        public void UpdateQuantityOfProduct(project0Context context, int storeId, int productId, int request)
        {
            int quantityInstock = GetQuantityOfProduct(context, productId, storeId);//check the quantity of product in stock
            if (quantityInstock > request)
            {
                quantityInstock -= request;//reducing the quantity if there is enough product in the stock
            }

            var inventory = context.Inventory
                .Where(i => i.ProductId == productId && i.StoreId == storeId)
                .ToList();

            foreach (Inventory ts in inventory)//get the quantity part of the inventory and assigning it new value
            {
                ts.Quantity = quantityInstock;
                context.Inventory.Update(ts);//updating the database with new information
                context.SaveChangesAsync();
            }


        }

        /// <summary>
        /// This method is use to get the product id given the name of the product
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <returns name="productId"></returns>
        public int GetProductIdByName(project0Context context, string name)
        {
            
            if(name == "")
            {
                Console.WriteLine("No product with such name");
            }

            var inventory = context.Inventory.FirstOrDefault(i => i.Name == name);
            if(inventory == null)
            {
                Console.WriteLine("No such product in stock now");
                return -1;
            }
            return inventory.InventoryId;//returning the result of the query
        }

    }
    
    
}
