using System;
using System.Collections.Generic;
using System.Text;

namespace Blogpost.Core.Application.Exception
{
    public class InvalidDataProvidedException : BaseException
    {
        public InvalidDataProvidedException()
            : base()
        {
        }
        public InvalidDataProvidedException(string message)
            : base(message)
        {
        }
    }
}
