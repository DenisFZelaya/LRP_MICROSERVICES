

using Loans.API.Aplication.Dtos.Response;

namespace Loans.API.Domain.Interfaces
{
    public interface IRequestDetailsService
    {
        public Task<JsonCustomResponse> GetRequestDetails(string hashId);
    }
}
