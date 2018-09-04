using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepsoitory
    {
        Task<User> Registar(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);

    }
}
