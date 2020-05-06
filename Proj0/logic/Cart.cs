using Proj0.Dal;


namespace Proj0.Pages
{
    class Cart
    {
        readonly OrderDal cart = new OrderDal();

        public Cart()
        {
            
        }
        
        public void Buying(project0Context context)
        {
            cart.PlaceOrder(context);
        }

    }
}
