﻿using Blogpost.Application.Attributes;
using Blogpost.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blogpost.Core.User.Domain;
using Blogpost.Core.User.Model;

namespace Blogpost.Core.User.Impl
{
    [DefaultImplementation]
    public class UserLoginService : IUserLoginService
    {
 
        private readonly IRepository<Person> _personRepository;
        public UserLoginService(IUnitOfWork unitOfWork)
        {
          
            _personRepository = unitOfWork.Repository<Person>();
        }

        public Person GetbyUserName(string userName)
        {
            var person = _personRepository.Table.FirstOrDefault(x => x.Email.Trim().ToLower().Equals(userName.Trim().ToLower()) || x.UserName.ToLower().Equals(userName.ToLower()));
            return person;
        }
        public bool SignUp(SignUpModel model)
        {
            var person = new Person {

                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                IsNew = true,
            };
            _personRepository.Save(person);
            return true;
        }


        public Person GetbyUserId(long userId)
        {
            return _personRepository.Get(userId);
        }


        public bool IsUniqueUserName(string userName, long userId = 0)
        {
            return !_personRepository.Table.Any(p => p.UserName.ToLower() == userName.ToLower() && (userId < 1 || userId != p.Id));
        }

        public bool IsUniqueEmailAddress(string email, long userId = 0)
        {
            if (email == null) return true;
            string upperEmail = email.ToUpper();
            return !_personRepository.Table.Any(p => upperEmail == p.Email.ToUpper() && (userId < 1 || userId != p.Id));
        }



    }
}
