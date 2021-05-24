using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly ScheduleContext _context;
        public UserRepository(ScheduleContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUser(string emailAddress)
        {
            var user = _context.Users.Where(user => user.Email == emailAddress).FirstOrDefault();
            user.Password = null;
            
            return user;
        }

        public void CreateUser (User user)
        {
            if (string.IsNullOrEmpty(user.Password))
                throw new ArgumentNullException("Password is required.");

            if (_context.Users.Any(u => u.Email == user.Email))
                throw new ArgumentException("User \"" + user.Email + "\" is already taken.");

            _context.Users.Add(user);
                    }
    }
}