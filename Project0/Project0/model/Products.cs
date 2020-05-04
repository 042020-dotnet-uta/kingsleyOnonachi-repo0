using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{

    public partial class Products
    {
        public Products()
        {
            Orderlist = new HashSet<Orderlist>();
            StoreNavigation = new HashSet<Store>();
        }
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int storeId { get; set; }

        public int? Quantity { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public double ListPrice { get; set; }


        public virtual Store Store { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
        public virtual ICollection<Store> StoreNavigation { get; set; }

    }
}
