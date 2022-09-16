using System;

namespace OnlineShop.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : 
            base(message ?? "Oops. There was someting wrong with your request.") { }
    }
}
