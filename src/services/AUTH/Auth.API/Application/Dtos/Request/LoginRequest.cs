using System.ComponentModel.DataAnnotations;

namespace Auth.API.Application.Dtos.Request
{
    public class LoginRequest
    {
        //
        [EmailAddress(ErrorMessage = "El campo email no tiene un formato válido")]
        [StringLength(50, MinimumLength = 6)]
        public string email { get; set; }


        //
        [Required(ErrorMessage = "El campo password es requerido")]
        [StringLength(50, MinimumLength = 6)]
        public string password { get; set; }
    }
}
