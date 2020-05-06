using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
        }
        private int storeId;
        private string streetAddress;
        private string cityAddress;
        private string stateAddress;
        private string countryAddress;

        public string CountryAddress
        {
            get { return countryAddress; }
            set { countryAddress = value; }
        }


        public string StateAddress
        {
            get { return stateAddress; }
            set { stateAddress = value; }
        }


        public string CityAddress
        {
            get { return cityAddress; }
            set { cityAddress = value; }
        }


        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }


        public int StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
