using System;
using System.Collections.Generic;

namespace Proj0
{
    public partial class Customers
    {
        public Customers()
        {
            Defaultstore = new HashSet<Defaultstore>();
            Orders = new HashSet<Orders>();
        }
        private int customerId;
        private string firstName;
        private string lastName;
        private string streetAddress;
        private string cityAddress;
        private string stateAddress;
        private string countryAddress;
        private string userName;
        private string passWord;
        private DateTimeOffset? regDate;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set {customerId = value; }
        }

        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public string StreetAddress {
            get { return streetAddress; }
            set { streetAddress = value; }
        }
        public string CityAddress {
            get { return cityAddress; }
            set { cityAddress = value; }
        }
        public string StateAddress {
            get { return stateAddress; }
            set { stateAddress = value; }
        }
        public string CountryAddress {
            get { return countryAddress; }
            set { countryAddress = value; }
        }
        public string UserName {
            get { return userName; }
            set { userName = value; }
        }
        public string PassWord {
            get { return passWord; }
            set { passWord = value; }
        }
        public DateTimeOffset? RegDate {
            get { return regDate; }
            set { regDate = value; }
        }

        public virtual ICollection<Defaultstore> Defaultstore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
