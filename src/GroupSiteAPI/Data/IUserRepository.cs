using System.Collections.Generic;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUser(string email);
        void CreateUser(User user);
    }
}