using System;
using System.Collections.Generic;
using System.Text;

namespace Blogpost.Core.User
{
    public interface IUserLogService
    {
        void SaveLoginSession(long userId, string sessionId,
            DateTime loginDateTime );

        void EndLoggedinSession(string token);

    }
}
