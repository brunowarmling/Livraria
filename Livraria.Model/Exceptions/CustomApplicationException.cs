using Livraria.Model.Logging;
using System;

namespace Livraria.Model.Exceptions
{

    /// <summary>
    /// The purpose of this exception is to log application exceptions
    /// </summary>
    [Serializable]
    public class CustomApplicationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomApplicationException"/> class
        /// </summary>
        public CustomApplicationException()
        {
            Log.AddError(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomApplicationException"/> class
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public CustomApplicationException(string message) : base(message)
        {
            Log.AddError(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomApplicationException"/> class
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference</param>
        public CustomApplicationException(string message, Exception inner) : base(message, inner)
        {
            Log.AddError(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomApplicationException"/> class
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information
        /// about the source or destination.</param>
        protected CustomApplicationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
