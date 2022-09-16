using System;

namespace OnlineShop.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message = null) : 
            base(message ?? "You are forbid to access this resource.") { }
    }
}
