using System;
using System.Runtime.Serialization;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("The request was malformed or contains unsupported elements!")
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(Exception innerException) : base("The request was malformed or contains unsupported elements!", innerException)
        {
        }
    }
}