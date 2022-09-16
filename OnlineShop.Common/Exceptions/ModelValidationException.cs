using System;
using System.Collections.Generic;

namespace OnlineShop.Common.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message = null, IDictionary<string, IEnumerable<string>> failures = null) : 
            base(message ?? "One or more validation failures have occurred.")
        {
            Failures = failures ?? new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Failures { get; }
    }
}
