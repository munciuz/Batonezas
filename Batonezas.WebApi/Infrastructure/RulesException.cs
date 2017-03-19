using System;
using System.Collections.Generic;
using System.Linq;

namespace Batonezas.WebApi.Infrastructure
{
    public class RulesException : Exception
    {
        public IEnumerable<ErrorInfo> Errors { get; private set; }

        public RulesException()
        {
            Errors = new List<ErrorInfo>();
        }

        public RulesException(IEnumerable<ErrorInfo> errors)
        {
            Errors = errors;
        }

        public RulesException(string errorMessage) : this(string.Empty, errorMessage)
        {
        }

        public RulesException(string propertyName, string errorMessage)
        {
            Errors = new[] { new ErrorInfo(propertyName, errorMessage) };
        }

        public override string Message
        {
            get
            {
                return Errors.Any() ? Errors.First().ErrorMessage : base.Message;
            }
        }
    }
}