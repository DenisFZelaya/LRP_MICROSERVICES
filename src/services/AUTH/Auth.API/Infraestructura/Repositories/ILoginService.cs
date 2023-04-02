using Auth.API.Dtos.Request;
using Auth.API.Dtos.Response;

namespace Auth.API.Infraestructura.Repositories
{
    public interface ILoginService
    {
        Task<JsonCustomResponse> Login(LoginRequest login);
        Task<JsonCustomResponse> Logout(string token);
        Task<JsonCustomResponse> RefreshToken(string token);

        Task<JsonCustomResponse> Registrer(LoginRequest login);
        Task<JsonCustomResponse> UpdateUser(LoginRequest login);
        Task<JsonCustomResponse> ForgotPassword(string email, string token);
        Task<JsonCustomResponse> ResetPassword(ResetPasswordRequest resetPassword, string token);
    }
}
