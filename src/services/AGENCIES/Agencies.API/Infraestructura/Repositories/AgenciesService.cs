using Agencies.API.Data;
using Agencies.API.Dtos.Request;
using Agencies.API.Dtos.Response;
using Agencies.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agencies.API.Infraestructura.Repositories
{
    public class AgenciesService : IAgenciesService
    {

        private readonly AGENCIESContext _context;

        public AgenciesService(AGENCIESContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crear una agencia
        /// </summary>
        /// <param name="agencia"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Agencias> CreateAsync(Agencias agencia)
        {
            // Agregar guid
            agencia.IdHash = Guid.NewGuid().ToString();
            agencia.CreadaEn = DateTime.Now;
            agencia.ActualizadaEn = DateTime.Now;

            // Guardar registro
            _context.Agencias.Add(agencia);
            int success = await _context.SaveChangesAsync();
            if(success == 0) {
                throw new Exception(message: "No se pudo crear el registro");
            }
            Console.WriteLine(success);
            return agencia;
        }

        /// <summary>
        /// Eliminar agencia
        /// </summary>
        /// <param name="idHash"></param>
        /// <returns></returns>
        public async Task<JsonCustomResponse> DeleteAsync(string idHash)
        {
            JsonCustomResponse response = new JsonCustomResponse();

            try
            {
                Agencias agency = await _context.Agencias.Where(_ => _.IdHash.Equals(idHash)).FirstOrDefaultAsync();

                if (agency == null)
                {
                    response.Success = false;
                    response.Message = "No se ha encontrado el registro: " + idHash;
                    return response;
                }
                _context.Agencias.Remove(agency);
                response.Success = await _context.SaveChangesAsync() == 1;
                response.Message = response.Success ? "Se elimino el registro: " + idHash : "No se pudo eliminar el registro: " + idHash;
                response.Data = agency;
                response.ServerCode = 200;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.ServerCode = 400;
            }

            return response;
        }

        public async Task<JsonCustomResponse> GetAllAsync(int? idPais, int? idDepartamento, int? idCiudad,int? limit, int? offset)
        {
            JsonCustomResponse response = new JsonCustomResponse();

            try
            {
                var users = _context.Agencias.AsQueryable();
                

                if (idPais != null)
                {
                    users = users.Where(u => u.IdPais == idPais);

                    if (idDepartamento != null)
                    {
                        users = users.Where(u => u.IdDepartamento == idDepartamento);

                        if (idCiudad != null)
                        {
                            users = users.Where(u => u.IdCiudad == idCiudad);
                        }
                    }
                }

                int allCount = users.Count();

                if (limit != null)
                {
                    int limite = (int)(limit == null ? 0 : limit);
                    if(offset != null)
                    {
                        // hay offset
                        users = users.Skip((int)offset).Take(limite);
                    }
                    else
                    {
                        users = users.Take(limite);
                    }
                    

                }

                // List<Agencias> agencias = await _context.Agencias.ToListAsync();
                // var agencias = await _context.Agencias.Where(_ => _.IdPais.(idPais)).Skip(offset).Take(limit <= 0 ? 100 : limit).ToListAsync();
                response.Success = true;
                response.Data = new
                {
                    
                    ItemsCount = users.Count(),
                    AllCount = allCount,
                    Fecha = DateTime.Now,
                    Params = new
                    {
                        idPais = idPais,
                        idDepartamento = idDepartamento,
                        idCiudad = idCiudad,
                        limit = limit,
                        offset = offset,

                    },
                    Items = users,
                };
                response.ServerCode = 200;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.ServerCode = 400;
            }

            return response;
        }

        public async Task<Agencias> GetByIdAsync(string idHash)
        {

            return await _context.Agencias.Where(c => c.IdHash.Equals(idHash)).FirstOrDefaultAsync();

        }

        public async Task<JsonCustomResponse> UpdateAsync(string idHash, CreateUpdateAgencyRequest agenciaUpdate)
        {
            JsonCustomResponse response = new JsonCustomResponse();

            try
            {
                // Obtener registro a actualizar
                Agencias agenciaDb = await _context.Agencias.Where(_ => _.IdHash.Equals(idHash)).FirstOrDefaultAsync();

                // Campos a actualizar
                agenciaDb.Nombre = agenciaUpdate.Nombre;
                agenciaDb.IdPais = agenciaUpdate.IdPais;
                agenciaDb.IdDepartamento = agenciaUpdate.IdDepartamento;
                agenciaDb.IdCiudad = agenciaUpdate.IdCiudad;
                agenciaDb.Direccion = agenciaUpdate.Direccion;
                agenciaDb.Latitud = agenciaUpdate.Latitud;
                agenciaDb.Longitud = agenciaUpdate.Longitud;
                agenciaDb.ActualizadaEn = DateTime.Now;

                // Actualizar registro
                _context.Entry(agenciaDb).State = EntityState.Modified;

                response.Success = await _context.SaveChangesAsync() == 1;
                response.Message = response.Success ? "Se actualizo el registro: " + idHash : "No se pudo actualizar el registro: " + idHash;
                response.ServerCode = 200;
                response.Data = agenciaUpdate;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Message;
            }
            return response;
        }
    }
}
