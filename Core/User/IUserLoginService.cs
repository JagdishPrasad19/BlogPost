using Blogpost.Core.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogpost.Core.User
{
    public interface IUserLoginService
    {
        Domain.Person GetbyUserName(string userName);
        Domain.Person GetbyUserId(long userId);
        bool SignUp(SignUpModel model);


        bool IsUniqueUserName(string userName, long userId = 0);
        bool IsUniqueEmailAddress(string email, long userId = 0);
    }
}
