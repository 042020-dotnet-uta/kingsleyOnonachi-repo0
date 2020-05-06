using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Inventory
    {
        private int productId;
        private int storeId;
        private int quantity;
        private int inventoryId;
        private string name;
        private string description;
        private double listPrice;

        public double ListPrice
        {
            get { return listPrice; }
            set { listPrice = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int InventoryId
        {
            get { return inventoryId; }
            set { inventoryId = value; }
        }


        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public virtual Store Store { get; set; }
    }
}
