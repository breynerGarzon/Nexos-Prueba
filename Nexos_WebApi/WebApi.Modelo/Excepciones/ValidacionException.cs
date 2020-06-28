using System;
using System.Runtime.Serialization;

namespace WebApi.Modelo.Excepciones
{
    public class ValidacionException : Exception
    {
        public ValidacionException()
        {
        }

        public ValidacionException(string message) : base(message)
        {
        }

        public ValidacionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidacionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}