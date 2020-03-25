﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.DTO;

namespace APIServer.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<bool> Login(string email, string password);
    }
}
