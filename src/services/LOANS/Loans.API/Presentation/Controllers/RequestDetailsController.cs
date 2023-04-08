using Loans.API.Aplication.Dtos.Response;
using Loans.API.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Loans.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailsController : ControllerBase
    {
        private readonly IRequestDetailsService _service; 
        public RequestDetailsController(IRequestDetailsService service)
        {
            _service = service;
        }

        [HttpGet("{hashId}")]
        public async Task<JsonCustomResponse> Get([Required] string hashId) {
            return await _service.GetRequestDetails(hashId);
        }
    }
}
