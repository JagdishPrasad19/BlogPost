using System;
using System.Collections.Generic;
using System.Text;

namespace Blogpost.Core.User.Model
{
    public class UserSessionModel
    {
        public long  UserId { get; set; }
        public string UserName { get; set; }
        public long LogId { get; set; }
    }
}
