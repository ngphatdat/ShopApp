using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Response;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController: ControllerBase
{   
        private  readonly   IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync(SignUpViewModel signUpViewModel)
        {
            var result = await _accountService.SignUpAsync(signUpViewModel);
            if (result.Succeeded)
            {
                return Ok("User Created Successfully");
            }
            return Unauthorized();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInViewModel signInViewModel)
        {
            try
            {
                var signInResponse = await _accountService.SignInAsync(signInViewModel);
                return Ok(signInResponse);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }