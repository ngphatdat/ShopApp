using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebApplication5.Models;
using WebApplication5.Response;
using WebApplication5.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApplication5.Repositories;

public class AccountRepository:IAccountRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    public AccountRepository(UserManager<
            ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _roleManager = roleManager;
    }
    public async Task<IdentityResult> SignUp(SignUpViewModel signUpViewModel)
    {
        var user = new ApplicationUser()
        {
            FistName = signUpViewModel.FirstName,
            LastName = signUpViewModel.LastName,
            UserName = signUpViewModel.UserName,
            Email = signUpViewModel.Email
        };
        var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
        if (result.Succeeded)
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
            }
            await _userManager.AddToRoleAsync(user, AppRole.Admin);
        }
        
        return result;
    }

    public async Task<SignInResponse> SignIn(SignInViewModel signInViewModel)
    {   //kiểm tra thông tin đăng nhập
        var result = await _signInManager.PasswordSignInAsync(signInViewModel.UserName, signInViewModel.Password, false, false);
        var user = await _userManager.FindByNameAsync(signInViewModel.UserName);
        if (user == null)
        {
            throw new Exception("Invalid Login Attempt");
        }
        var validPassword = await _userManager.CheckPasswordAsync(user, signInViewModel.Password);
        if (!result.Succeeded||!validPassword||user == null)
        { 
            throw new Exception("Invalid Login Attempt");
        }
        //tạo claim
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, signInViewModel.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var userRoles = await _userManager.GetRolesAsync(user);
        //gán role vào claim
        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        //tạo token
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));   
        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:ValidIssuer"],
            audience: _configuration["JwtSettings:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        //trả về token
            var signInResponse = new SignInResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Login Success",
            };
        return signInResponse;
    }
}