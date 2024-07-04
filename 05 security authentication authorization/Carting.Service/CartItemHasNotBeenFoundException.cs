namespace Carting.Service
{
    public class CartItemHasNotBeenFoundException : Exception
    {
        public CartItemHasNotBeenFoundException()
        {
        }

        public CartItemHasNotBeenFoundException(string message)
            : base(message)
        {
        }

        public CartItemHasNotBeenFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}