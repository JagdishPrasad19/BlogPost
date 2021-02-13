using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogpost.Core.Application;


namespace Blogpost.API.Application.Impl
{
    public class SessionContext : ISessionContext
    {
        public Core.User.Model.UserSessionModel UserSession { get; set; }

        public string SessionId { get; set; }
    }
}
