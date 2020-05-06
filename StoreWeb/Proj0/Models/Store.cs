using System;
using System.Collections.Generic;

namespace Proj0.Models
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int StoreId { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string CountryAddress { get; set; }
        //public int? ProductId { get; set; }

        public virtual Inventory Product { get; set; }
        public virtual Defaultstore Defaultstore { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
