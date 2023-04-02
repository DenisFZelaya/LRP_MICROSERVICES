using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Agencies.API.Infraestructura.Filters
{
    public class AuthorizeMS : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
            // Console.WriteLine("Prueba");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string Authorization = context.HttpContext.Request.Headers["Authorization"];

            // Aqui validar el token con el servicio de AUTH

            // Validar el nivel de acceso

            if (string.IsNullOrEmpty(Authorization) )
            {
                context.Result = new UnauthorizedResult();
            }

            if (Authorization != "Bearer dfz")
            {
                context.Result = new UnauthorizedResult();
            }

        }
    }
}
