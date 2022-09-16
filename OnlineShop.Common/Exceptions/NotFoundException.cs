using System;

namespace OnlineShop.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : 
            base(message ?? "Requested resource(s) is not found.") { }
    }
}
