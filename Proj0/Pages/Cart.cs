using Proj0.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proj0.Pages
{
    class Cart
    {
        readonly OrderDal cart = new OrderDal();
        public Cart(project0Context context)
        {
            cart.PlaceOrder(context);
        }
        
        

    }
}
