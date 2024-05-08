using Microsoft.AspNetCore.Identity;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Repositories;

public interface IAccountRepository
{
    Task<IdentityResult> SignUp(SignUpViewModel signUpViewModel);
    Task<string> SignIn(SignInViewModel signInViewModel);
}