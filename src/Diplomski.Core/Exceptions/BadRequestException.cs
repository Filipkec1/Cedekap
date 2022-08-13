﻿using System.Net;

namespace Diplomski.Core.Exceptions
{
    /// <summary>
    /// An exception that is thrown when a bad request happens.
    /// </summary>
    public class BadRequestException : CustumeException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
