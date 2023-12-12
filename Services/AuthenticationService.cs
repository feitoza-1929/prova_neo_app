using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using Shared.DTOs;

namespace Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthenticationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;

    }
    public async Task<Result> CreateUserAsync(UserCreateDto userCreate)
    {
        var user = _mapper.Map<UserCreateDto, User>(userCreate);

        var userExists = await _userManager.FindByNameAsync(user.UserName);
        if (userExists != null)
            return Result.Fail("User already exists");

        var result = await _userManager.CreateAsync(user, userCreate.Password);
       
        if(!result.Succeeded)
            return Result.Fail("User already exists");

        await _userManager.AddToRolesAsync(user, userCreate.Roles);

        return Result.Ok();
    }

    public async Task<Result<string>> AuthenticateUserAsync(UserAuthenticationDto userAuth)
    {
        var user = await _userManager.FindByNameAsync(userAuth.UserName);

        if(user is null)
            return Result.Fail("Invalid request");

        if (!await _userManager.CheckPasswordAsync(user, userAuth.Password))
            return Result.Fail("Invalid request");

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        return Result.Ok(GenerateToken(authClaims));
    }


    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWT:ValidIssuer"],
            Audience = _configuration["JWT:ValidAudience"],
            Expires = DateTime.Now.AddHours(double.Parse(_configuration["JWT:Expires"])),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}