using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Auth.API.Infraestructura.Filters
{
    public class AuthorizeCompany : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
            // Console.WriteLine("Prueba");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            

        }
    }
}
