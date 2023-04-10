using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ExampleController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate()
    {
        // Aquí puedes agregar la lógica para autenticar al usuario y obtener sus datos
        // En este ejemplo, se están creando claims estáticos solo para demostración

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "usuarioEjemplo"),
            new Claim(ClaimTypes.Email, "denisfzelaya@gmail.com"),
            new Claim(ClaimTypes.Role, "rolEjemplo")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    [AllowAnonymous]
    [HttpGet("token")]
    public IActionResult GetToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // clave secreta para firmar el token
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256); // algoritmo de seguridad para firmar el token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "denisfzelaya"),
            new Claim(JwtRegisteredClaimNames.Email, "denisfzelaya@gmail.com"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }; // claims para incluir en el token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials); // generamos el token

        return Ok(new
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(token)
        }); // devolvemos el token como string
    }

    [AllowAnonymous]
    [HttpGet("decodedToken")]
    public IActionResult GetDecodedToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = secretKey,
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Issuer"],
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var email = jwtToken.Claims.First(x => x.Type == "email").Value;
            //var email = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
            //var userId = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;

            return Ok(new {email = email, Claims = jwtToken.Claims });
        }
        catch (Exception ex)
        {
            return BadRequest("Token inválido");
        }
    }
}
