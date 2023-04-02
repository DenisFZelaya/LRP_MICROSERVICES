using Agencies.API.Data;
using Agencies.API.Dtos.Request;
using Agencies.API.Dtos.Response;
using Agencies.API.Infraestructura.Repositories;
using Agencies.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencies.API.Controllers
{
    [Route("api/v1/ms-agencies")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly IAgenciesService _agenciesService;
        public AgenciasController(IAgenciesService agenciesService)
        {
            this._agenciesService = agenciesService;
        }


        [HttpGet]
        public async Task<JsonCustomResponse> Get(int? idPais, int? idDepartamento, int? idCiudad, int? limit, int? offset)
        {
            return await _agenciesService.GetAllAsync(idPais, idDepartamento, idCiudad, limit,offset );
        }

        [HttpGet("{idHash}")]
        public async Task<ActionResult<Agencias>> GetById(string idHash)
        {
            var product = await _agenciesService.GetByIdAsync(idHash);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Agencias>> Create(CreateUpdateAgencyRequest agenciaCreate)
        {
            Agencias agenciaNueva = new Agencias();
            agenciaNueva.Nombre = agenciaCreate.Nombre;
            agenciaNueva.IdPais = agenciaCreate.IdPais;
            agenciaNueva.IdDepartamento = agenciaCreate.IdDepartamento;
            agenciaNueva.IdCiudad = agenciaCreate.IdCiudad;
            agenciaNueva.Direccion = agenciaCreate.Direccion;
            agenciaNueva.Latitud = agenciaCreate.Latitud;
            agenciaNueva.Longitud = agenciaCreate.Longitud;

            Agencias agencia = await _agenciesService.CreateAsync(agenciaNueva);

            return agencia;
        }

        // Actualizar un registro
        [HttpPut("{idHash}")]
        public async Task<JsonCustomResponse> UpdateAsync(string idHash, CreateUpdateAgencyRequest agencia)
        {
            return await _agenciesService.UpdateAsync(idHash, agencia); ;
        }

        // Eliminar un registro
        [HttpDelete("{idHash}")]
        public async Task<JsonCustomResponse> Delete(string idHash)
        {            
            return await _agenciesService.DeleteAsync(idHash);
        }

    }
}
