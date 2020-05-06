using Proj0.Dal;
using Proj0.Pages;
using System;

namespace Proj0.store
{
    class Menu
    {
        public Menu()
        {

        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to World Electronics Where Technology Meets Creativity");
            Console.WriteLine("How May I Help Today. Enter 'B' for Shoping; 'C' to get Customer's Information");
            Console.WriteLine("Or 'S' for Store Locationss and 'V' to view Orders History:");

            string str = Console.ReadLine();
            //check if the user input the right variable 
            while (str.Length > 1)
            {
                Console.WriteLine("Welcome to World Electronics Where Technology Meets Creativity");
                Console.WriteLine("How May I Help Today. Enter 'B' for Shoping; 'C' to get Customer's Information");
                Console.WriteLine("Or 'S' for Store Locationss and 'V' to view Orders History:");

                str = Console.ReadLine();
            }
            char choice;
            //this allows the usee to enter input in lower case
            string ch = str.ToUpper();
            choice = ch[0];
            using project0Context context = new project0Context();
            Cart cart = new Cart();

            switch (choice)
            {
                case 'B':
                    cart.Buying(context);
                    BackToMenu();
                    break;
                case 'C':
                    CustomerDal customer = new CustomerDal();
                    customer.CustomersHome(context);
                    BackToMenu();
                    break;
                case 'V':
                    OrderDal order = new OrderDal();
                    order.DisplayCustomerHist(context, 1);
                    BackToMenu();
                    break;

                case 'S':
                    StoreDal store = new StoreDal();
                    Console.WriteLine("showing store 1:");
                    store.ShowStoreAddress(context, 1);
                    BackToMenu();
                    break;
                default:
                    BackToMenu();
                    break;
            }


        }

        public void BackToMenu()
        {
            DisplayMenu();
        }

    }
}
