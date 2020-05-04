using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{
    public partial class Store
    {
        
        [Key]
        public int storeId { get; set; }
        public int productId { get; set; }

        public string streetAddress { get; set; }
        public string cityAddress { get; set; }
        public string stateAddress { get; set; }
        public string countryAddress { get; set; }
        

        

        public Store()
        {
        }
    }
}
