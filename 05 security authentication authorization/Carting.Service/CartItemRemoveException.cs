namespace Carting.Service
{
    public class CartItemRemoveException : Exception
    {
        public CartItemRemoveException()
        {
        }

        public CartItemRemoveException(string message)
            : base(message)
        {
        }

        public CartItemRemoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}