using Blogpost.Core.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogpost.Core.User.Domain
{
    public class Person : DomainBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
