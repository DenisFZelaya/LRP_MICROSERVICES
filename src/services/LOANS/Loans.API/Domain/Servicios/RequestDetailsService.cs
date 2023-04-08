using Loans.API.Aplication.Dtos.Response;
using Loans.API.Data;
using Loans.API.Domain.Interfaces;
using Loans.API.Infraestructure.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Loans.API.Domain.Servicios
{
    public class RequestDetailsService : IRequestDetailsService
    {
        private readonly LOANSContext _context;
        public RequestDetailsService(LOANSContext context)
        {
            _context = context; 
        }

        public async Task<JsonCustomResponse> GetRequestDetails(string hashId)
        {
            JsonCustomResponse response = new JsonCustomResponse();

            try
            {
                Solicitudes solicitudes = await _context.Solicitudes.Where(_ => _.IdHash.Equals(hashId)).FirstOrDefaultAsync();

                if (solicitudes == null)
                {
                    response.Success = false;
                    response.Message = "Solicitud no encontrado";
                    return response;
                }

                Clientes cliente = await _context.Clientes.Where(_ => _.Cedula.Equals(solicitudes.CedulaCliente)).FirstOrDefaultAsync();

                response.Data = new
                {

                    prueba = "Agreando dato",
                    resumen = new
                    {
                        idHashSolicitud = hashId,
                        avales = 2,
                        Garantias = 3

                    },
                    solicitud = solicitudes,
                    cliente = new
                    {
                        cliente = cliente,
                        clienteConyugue = await _context.ClienteConyugue.Where(_ => _.CedulaCliente.Equals(solicitudes.CedulaCliente)).FirstOrDefaultAsync(),
                    },
                    garantias = new
                    {
                        avales = await _context.Avales.ToListAsync(),
                        garantias = await _context.Garantias.ToListAsync(),
                    },
                    referenciasPersonales = await _context.ReferenciasPersonales.ToListAsync(),
                    informacionFinanciera = new
                    {
                        EvaluacionFinanciera = await _context.EvaluacionFinanciera.Where((_ => _.Codsolicitud.Equals(solicitudes.CodSolicitud))).FirstOrDefaultAsync(),
                        inventario = await _context.Inventario.FirstOrDefaultAsync(),
                    },

                };

                response.ServerCode = 200;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ServerCode = 400;
                response.Message = ex.Message;
            }



            

            return response;
        }
    }
}


// evaluacionFinanciera =  new EvaluacionFinanciera(),
// inventario = new Inventario(),
