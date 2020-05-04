using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{
    public partial class Customers
    {

        public Customers()
        {
            Defaultstore = new HashSet<Defaultstore>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int customerId { get; set; }
        public int defaultStoreId { get; set; }

        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetAddress { get; set; }
        public string cityAddress { get; set; }
        public string stateAddress { get; set; }
        public string countryAddress { get; set; }
        public string? userName { get; set; }
        public string? passWord { get; set; }
        public DateTimeOffset RegDate { get; set; }

        public virtual ICollection<Defaultstore> Defaultstore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
