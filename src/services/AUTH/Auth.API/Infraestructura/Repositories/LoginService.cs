using Auth.API.Application.Dtos.Request;
using Auth.API.Application.Dtos.Response;
using Auth.API.Infraestructura.Context;
using Auth.API.Infraestructura.DBModels;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace Auth.API.Infraestructura.Repositories
{
    public class LoginService : ILoginService
    {
        private readonly AUTHContext _context;
        public LoginService(AUTHContext context)
        {
            _context = context;
        }
        public Task<JsonCustomResponse> ForgotPassword(string email, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<JsonCustomResponse> Login(LoginRequest login)
        {
            JsonCustomResponse response = new JsonCustomResponse();
            try
            {
                // Obtener usuario
                Login login1 = await _context.Login.Where(_ => _.Correo.Equals(login.email)).FirstOrDefaultAsync();

                // Validar email y password
                if (login1 == null)
                {
                    response.Success = false;
                    response.ServerCode = 401;
                    response.Message = "Sin autorizacion";
                    return response;
                }

                // hasheador
                // string passwordHash = BC.HashPassword(login.password);


                // Verificar contrasena
                bool passwordValid = BC.Verify(login.password, login1.PasswordHash);

                // Validar email y password
                if (passwordValid == false)
                {
                    response.Success = false;
                    response.ServerCode = 401;
                    response.Message = "Sin autorizacion";
                    return response;
                }


                response.Data = new
                {
                    token = Guid.NewGuid().ToString(),
                    expiration = DateTime.Now,
                    userInfo = new
                    {
                        displayName = "Denis Federico Zelaya",
                        email = "denisfzelaya@gmail.com",
                        localId = Guid.NewGuid().ToString(),
                        refreshToken = "",
                        expireIn = DateTime.Now.AddHours(8),
                        roles = new List<object> { new { id = 0, nombre = "ADM" }, new { id = 1, nombre = "RMNG" } },
                        agencies = new List<object> { new { id = Guid.NewGuid().ToString(), nombre = "Agencia SPS" }, new { id = Guid.NewGuid().ToString(), nombre = "Agencia SPS" } },

                    }
                };
                response.Success = true;
                response.ServerCode = 200;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ServerCode = 400;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<JsonCustomResponse> Logout(string token)
        {
            throw new NotImplementedException();
        }

        public Task<JsonCustomResponse> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<JsonCustomResponse> Registrer(LoginRequest login)
        {
            throw new NotImplementedException();
        }

        public Task<JsonCustomResponse> ResetPassword(ResetPasswordRequest resetPassword, string token)
        {
            throw new NotImplementedException();
        }

        public Task<JsonCustomResponse> UpdateUser(LoginRequest login)
        {
            throw new NotImplementedException();
        }
    }
}
