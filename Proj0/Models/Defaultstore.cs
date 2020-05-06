using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Defaultstore
    {
        private int defaultStoreId;
        private int userId;
        private DateTimeOffset? regDate;
        private int storeId;

        public int StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }


        public DateTimeOffset? RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }


        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int DefaultStoreId
        {
            get { return defaultStoreId; }
            set { defaultStoreId = value; }
        }
        
        public virtual Customers User { get; set; }
    }
}
