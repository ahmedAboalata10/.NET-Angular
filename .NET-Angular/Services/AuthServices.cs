using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MLG_Interview.Models.Helpers;
using MLG_Interview.Models.User;
using IServices;
using NETAngular.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models.Auth;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<AuthModel> Register(RegisterModel registerModel)
        {
            try
            {
                if (registerModel == null)
                {
                    throw new NullReferenceException("Register Model is null");
                }
                if (registerModel.Password != registerModel.ConfirmPassword)
                {
                    throw new Exception("Password and Confirm Password do not match");
                }
                if (await _userManager.FindByNameAsync(registerModel.UserName) is not null)
                {
                    throw new Exception("User with this username already exists");
                }
                if (await _userManager.FindByEmailAsync(registerModel.Email) is not null)
                {
                    throw new Exception("User with this email already exists");
                }
                var user = new ApplicationUser
                {
                    FirstName=registerModel.UserName,
                    LastName=registerModel.UserName,
                    Email = registerModel.Email,
                    UserName = registerModel.UserName
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("User creation failed! Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
                await _userManager.AddToRoleAsync(user, "User");
                var jwtSecurityToken = await CreateJwtToken(user);

                return new AuthModel
                {
                    Email = registerModel.Email,
                    UserName = registerModel.UserName,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    Roles = new List<string> { "User" },
                    Token= new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    IsAuthenticated = true,
                    Message = "User created successfully!"
                };


            }
            catch (Exception ex)
            {
                return new AuthModel
                {
                    IsAuthenticated = false,
                    Message = ex.Message
                };
            }
        }
        public Task<string> AddRoleAsync(AddRoleModel model)
        {
            throw new NotImplementedException();
        }
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();
            return authModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
