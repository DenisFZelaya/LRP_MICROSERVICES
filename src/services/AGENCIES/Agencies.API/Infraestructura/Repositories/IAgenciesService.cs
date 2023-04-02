using Agencies.API.Dtos.Request;
using Agencies.API.Dtos.Response;
using Agencies.API.Models;

namespace Agencies.API.Infraestructura.Repositories
{
    public interface IAgenciesService
    {
        Task<JsonCustomResponse> GetAllAsync(int? idPais, int? idDepartamento, int? idCiudad, int? limit, int? offset);
        Task<Agencias> GetByIdAsync(string idHash);
        Task<Agencias> CreateAsync(Agencias agencia);
        Task<JsonCustomResponse> UpdateAsync(string idHash, CreateUpdateAgencyRequest agencia);
        Task<JsonCustomResponse> DeleteAsync(string idHash);
    }
}
