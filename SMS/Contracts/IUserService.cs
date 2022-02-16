﻿using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Register(RegisterFormModel model);

        string Login(LoginFormModel model);

        string GetUsername(string userId);
    }
}
