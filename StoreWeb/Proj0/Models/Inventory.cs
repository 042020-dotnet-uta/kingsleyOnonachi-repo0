using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proj0.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Orderlist = new HashSet<Orderlist>();
            StoreNavigation = new HashSet<Store>();
        }

        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ListPrice { get; set; }

        [Key]
        public int InventoryId { get; internal set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
        public virtual ICollection<Store> StoreNavigation { get; set; }
       
    }
}
