using Auth.API.Dtos.Request;
using Auth.API.Dtos.Response;

namespace Auth.API.Infraestructura.Repositories
{
    public class LoginService : ILoginService
    {
        public Task<JsonCustomResponse> ForgotPassword(string email, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<JsonCustomResponse> Login(LoginRequest login)
        {
            JsonCustomResponse response = new JsonCustomResponse();

            response.Success = true;
            response.ServerCode = 200;
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
