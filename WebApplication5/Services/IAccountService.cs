using Microsoft.AspNetCore.Identity;
using WebApplication5.ViewModels;

namespace WebApplication5.Services;

public interface IAccountService
{
        Task<IdentityResult> SignUpAsync(SignUpViewModel signUpViewModel);
        Task<string> SignInAsync(SignInViewModel signInViewModel);
}