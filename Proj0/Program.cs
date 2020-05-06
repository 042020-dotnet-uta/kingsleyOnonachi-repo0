using Proj0.Dal;
using Proj0.Pages;
using Proj0.store;
using System;
using System.Linq;

namespace Proj0
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDal customerDal = new CustomerDal();
           
            using project0Context context = new project0Context();
            {
                Menu menu = new Menu();
                menu.DisplayMenu();
            }
        }
    }
}
