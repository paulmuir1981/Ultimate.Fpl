﻿namespace Fpl.Client.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, params object[] args)
            : base(string.Format(message, args)) { }
    }
}