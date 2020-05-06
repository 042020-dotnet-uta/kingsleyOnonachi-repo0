using System;
using System.Collections.Generic;

namespace Proj0.Models
{
    public partial class Defaultstore
    {
        public int DefaultStoreId { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset? RegDate { get; set; }

        public virtual Store DefaultStore { get; set; }
        public virtual Customers User { get; set; }
    }
}
