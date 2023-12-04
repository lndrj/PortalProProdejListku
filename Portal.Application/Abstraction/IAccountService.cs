using Portal.Infrastructure.Identity.Enums;
using System;
using Portal.Application.ViewModels;

namespace Portal.Application.Abstraction
{
    public interface IAccountService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
    }
}

