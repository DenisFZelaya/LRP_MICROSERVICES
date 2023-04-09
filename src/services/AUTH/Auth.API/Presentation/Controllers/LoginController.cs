using Auth.API.Infraestructura.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Security.Claims;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Auth.API.Application.Dtos.Request;
using Auth.API.Application.Dtos.Response;

namespace Auth.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService iLoginService)
        {
            _loginService = iLoginService;
        }


        [HttpPost]
        public async Task<JsonCustomResponse> Login(LoginRequest login)
        {
            JsonCustomResponse response = await _loginService.Login(login);

            // Autenticar al usuario
            bool isUserAuthenticated = true;
            string userName = "johndoe";
            string[] roles = { "admin", "user" };


            if (!User.Identity.IsAuthenticated)
            {
                ((ClaimsIdentity)User.Identity).AddClaim(new Claim(ClaimTypes.Name, "denisfzelaya"));
                ((ClaimsIdentity)User.Identity).AddClaim(new Claim(ClaimTypes.Email, "denisfzelaya@gmail.com"));

                foreach (var role in roles)
                {
                    ((ClaimsIdentity)User.Identity).AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }


            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claims = new
            {
                Name = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value,
                Email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value,
                Role = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value
            };

            response.Data = new
            {
                User.Identity,
                Claims = claims,
            };

            return response;
        }
    }
}
