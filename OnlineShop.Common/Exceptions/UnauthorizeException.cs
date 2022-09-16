using System;

namespace OnlineShop.Common.Exceptions
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException(string message = null) : 
            base(message ?? "You are not authorized.") { }
    }
}
