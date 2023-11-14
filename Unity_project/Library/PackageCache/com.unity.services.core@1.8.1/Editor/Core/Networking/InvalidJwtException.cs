using System;
using System.Runtime.Serialization;

namespace Unity.Services.Core.Editor
{
    /// <summary>
    /// Error occurred while decoding a JWT
    /// </summary>
    [Serializable]
    public class InvalidJwtException : Exception
    {
        /// <summary>
        /// Gets the error code for the failure.
        /// </summary>
        /// <remarks>
        /// See <see cref="CommonErrorCodes"/> for common error codes. Consult the
        /// service documentation for specific error codes various APIs can return.
        /// </remarks>
        public int ErrorCode => CommonErrorCodes.InvalidToken;

        /// <summary>
        /// The raw JWT that failed to decode.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Creates an exception.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        /// <param name="token">The raw JWT that failed to decode.</param>
        internal InvalidJwtException(string message, string token)
            : base(message)
        {
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidJwtException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        protected InvalidJwtException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}
    }
}
