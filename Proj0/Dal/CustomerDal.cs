using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proj0.Dal
{
    class CustomerDal
    {
    
        public CustomerDal()
        {
           
        }

        /// <summary>
        /// Adding new customer to the database
        /// input: customer object
        /// output: void
        /// </summary>
        /// <param name="ncustomer"></param>

        public void AddCustomer(project0Context context)
        {
            
            //using project0Context context = new project0Context();
            Customers customer = new Customers();
           
            //get the first name of the customer
            Console.WriteLine("Enter the customers first name:");
            customer.FirstName = Console.ReadLine();
            //get the customer last name
            Console.WriteLine("Enter the customers Last name:");
            customer.LastName = Console.ReadLine();
            //get the street address
            Console.WriteLine("Enter the customers Street address:");
            customer.StreetAddress = Console.ReadLine();

            //get the city address
            Console.WriteLine("Enter the customers City Address:");
            customer.CityAddress = Console.ReadLine();

            //get the state address
            Console.WriteLine("Enter the customers Sate Address:");
            customer.StateAddress = Console.ReadLine();

            //get the country address
            Console.WriteLine("Enter the customers Country Address:");
            customer.CountryAddress = Console.ReadLine();

            //get the username
            Console.WriteLine("Enter the customers username:");
            customer.UserName = Console.ReadLine();

            //get the password
            Console.WriteLine("Enter the customers password:");
            customer.PassWord = Console.ReadLine();

            customer.RegDate = DateTime.Now;

                context.Add(customer);
            context.SaveChanges()
;                
        }

        public Customers GetCustomerById(project0Context context, int Id)
        {
            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's customer id
            ///Input: customerId
            ///Output: custommer
            
            if(Id <= 0)
            {
                return NotFoundException();
            }
            var customer = context.Customers.FirstOrDefault(c => c.CustomerId == Id);
            if(customer == null)
            {
                return NotFoundException();
            }


            return customer;
        }


        public async Task<Customers> GetCustomerByUserNameAsync(project0Context context, string userName)
        {
            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's username
            ///Input: customer' username
            ///Output: custommer
            if(userName == null)//check that the input is not null
            {
                return NotFoundException();
            }
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.UserName == userName);

            if(customer == null)//check if the return value contain some information
            {
                return NotFoundException();
            }

            return customer;
        }

        private Customers NotFoundException()
        {
            throw new NotImplementedException();
        }

        public async Task<Customers> GetCustomerByFirstName(project0Context context)
        {
            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's customer, firstname
            ///Input: customer'firstname
            ///Output: custommer
            Console.WriteLine("Please enter the first name of the customer:");
            string firstName;
            if ((firstName = Console.ReadLine()) == " ")
            {
                return NotFoundException();
            }
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.FirstName == firstName);
             if(customer == null)
            {
                return NotFoundException();
            }

            return customer;
        }

        public Customers GetCustomerByFullName(project0Context context, string firstName, string lastName)
        {
            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's customer's firstName and Lastname
            ///Input: firstName and Lastname
            ///Output: custommer
            var customer = context.Customers
                .Where(c => c.FirstName == firstName && c.LastName ==lastName)
                .FirstOrDefault();
            return customer;
        }

        public List<Customers> GetAllCustomersByCity(project0Context context, string city)
        {
            ///Getting the list of all the customers in a given city
            ///Input: city
            ///Output: List of Customers
            List<Customers> customers = new List<Customers>();
            try {
                    customers = context.Customers
                    .Where(c => c.CityAddress == city)
                    .ToList();
            } catch (Exception e)
            {
                Console.WriteLine($"There seem we ahve a problem here : {e}");
            }
            finally
            {
                context.SaveChanges();

            }
             return customers;
        }
        
        

    }
    
}
