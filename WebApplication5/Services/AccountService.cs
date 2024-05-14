using Microsoft.AspNetCore.Identity;
using WebApplication5.Repositories;
using WebApplication5.Response;
using WebApplication5.ViewModels;

namespace WebApplication5.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public Task<IdentityResult> SignUpAsync(SignUpViewModel signUpViewModel)
    {
        return _accountRepository.SignUp(signUpViewModel);
    }

    public Task<SignInResponse> SignInAsync(SignInViewModel signInViewModel)
    {
        return _accountRepository.SignIn(signInViewModel);
    }
}