﻿using System;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Class representing a basic Vimeo exception.
    /// </summary>
    public class VimeoException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public VimeoException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public VimeoException(string message, Exception innerException) : base(message, innerException) { }

    }

}