using System.Collections.Generic;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        User Create(User user, string password);
        User GetById(int id);
    }
}