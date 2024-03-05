namespace CIS106ExceptionHandling.exceptions {

    /// <summary>
    /// This exception is thrown when an entity was not found when it was required,
    /// as is the case when attempting to delete or update an entity.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor accounting for just a custom message.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        /// <returns>The EntityNotFoundException to return.</returns>
        public EntityNotFoundException(string message) : base(message)
        {
        }

    }

}