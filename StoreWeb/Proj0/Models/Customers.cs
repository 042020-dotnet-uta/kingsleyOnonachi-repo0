using System;
using System.Collections.Generic;

namespace Proj0.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Defaultstore = new HashSet<Defaultstore>();
            Orders = new HashSet<Orders>();
        }
        //public Customers() { }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string CountryAddress { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTimeOffset? RegDate { get; set; }

        public virtual ICollection<Defaultstore> Defaultstore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
