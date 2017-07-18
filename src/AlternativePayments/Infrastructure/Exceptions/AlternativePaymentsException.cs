using System;
using System.Net;

namespace AlternativePayments
{
    public class AlternativePaymentsException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public Error Error { get; set; }

        public AlternativePaymentsException()
        {
        }

        public AlternativePaymentsException(HttpStatusCode httpStatusCode, Error error, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Error = error;
        }
    }
}
