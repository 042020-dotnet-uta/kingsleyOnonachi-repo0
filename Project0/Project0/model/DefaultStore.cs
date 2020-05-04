using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.model
{
    public partial class Defaultstore
    {
        public int defaultStoreId { get; set; }
        public int storeId { get; set; }
        public int customerId { get; set; }
        public DateTimeOffset RegDate { get; set; }

        public virtual Store DefaultStore { get; set; }
        public virtual Customers User { get; set; }
    }

}
