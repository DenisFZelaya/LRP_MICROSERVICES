using System.ComponentModel.DataAnnotations;

namespace Auth.API.Dtos.Request
{
    public class ResetPasswordRequest : LoginRequest
    {
        [Required(ErrorMessage = "El campo newPassword es requerido")]
        [StringLength(50, MinimumLength = 6)]
        public string NewPassword { get; set; }

    }
}
