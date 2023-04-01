using Agencies.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        readonly AGENCIESContext _context;
        public AgenciasController(AGENCIESContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public object Get()
        {
            return _context.Agencias.ToList();
        }
    }
}
