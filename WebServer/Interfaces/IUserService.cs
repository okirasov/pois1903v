using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interfaces
{
    public interface IUserService : IEntityService<User>
    {
        bool Login(string email, string password);
    }
}
