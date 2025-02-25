using EGWalks.API.Models.Dto;
using EGWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EGWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerUserDto.Password);

            if (identityResult.Succeeded) 
            {
                if (registerUserDto.Roles != null && registerUserDto.Roles.Any()) 
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerUserDto.Roles);
                    if (identityResult.Succeeded) 
                    {
                        return Ok("Registered Successfully, please log in from the log in page.");
                    }
                }
            }
            return BadRequest("invalid input");

        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> Login([FromBody] LogInRequestDto logInRequestDto)
        {
            var user = await userManager.FindByEmailAsync(logInRequestDto.UserName);
            if (user != null) 
            {
                var basswordCheck = await userManager.CheckPasswordAsync(user, logInRequestDto.Password);
                if(basswordCheck)
                {
                    // Get Roles For the user
                    var roles = await userManager.GetRolesAsync(user);
                    //get jwt token
                    if(roles != null)
                    {
                        var token = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResonseDto { JwtToken = token };
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest("password incorrect");
                }
            }
            return BadRequest("username incorrect");
        }
    }
}
