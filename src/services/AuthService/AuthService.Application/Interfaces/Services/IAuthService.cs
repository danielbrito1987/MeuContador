﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string name, string email, string password);
        Task<string?> LoginAsync(string email, string password);
    }
}
