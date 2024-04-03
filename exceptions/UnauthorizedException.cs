using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CIS106ExceptionHandling.exceptions
{
    /// <summary>
    /// This exception is thrown when a user attempts to access a resource without being authorized
    /// </summary>
    public class UnauthorizedException : Exception
    {
        /// <summary>
        /// Constructor used to take a custom exception message when UnauthorizedException is thrown
        /// </summary>
        /// <param name="message">The custom exception message</param>
        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}