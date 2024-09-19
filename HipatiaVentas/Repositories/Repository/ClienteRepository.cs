using AutoMapper;
using HipatiaVentas.Commun;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HipatiaVentas.Repositories.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger createLogger;
        private readonly IMapper mapper;

        public ClienteRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger _createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            this.createLogger = _createLogger;
        }

        public async Task<Result> GetAllClientes()
        {
            Result oRespuesta = new Result();

            List<ClienteDto> lstTemp = new List<ClienteDto>();

            try
            {
                lstTemp = await (from p in objContext.Clientes
                                 join td in objContext.ParametrosGenerales on p.TipoDocumentoId equals td.Id
                                 join tp in objContext.ParametrosGenerales on p.TipoPersonaId equals tp.Id
                                 select new ClienteDto
                                 {
                                     Id = p.Id,
                                     TipoDocumentoId = p.TipoDocumentoId,
                                     Numero = p.Numero,
                                     Nombre = p.Nombre,
                                     Direccion = p.Direccion,
                                     Estado = p.Estado,
                                     NombreRepresentante = p.NombreRepresentante,
                                     Telefono = p.Telefono,
                                     Email = p.Email,
                                     IsActive = p.IsActive,
                                     NombreTipoDocumento = td.Nombre,
                                     NombreTipoPersona = tp.Nombre,
                                 }).ToListAsync();

                if (lstTemp.Count > 0)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> GetClienteById(int? Id)
        {
            Result oRespuesta = new Result();

            ClienteDto objTemp = new ClienteDto();

            try
            {
                var objResult = await objContext.Clientes.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();

                if (objResult != null)
                {
                    objTemp = mapper.Map<ClienteDto>(objResult);

                    oRespuesta.Success = true;
                    oRespuesta.Data = objTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> InsertCliente(CrearClienteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Cliente>(entity);

                await objContext.AddAsync(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegGuardado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> UpdateCliente(ClienteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Cliente>(entity);

                objContext.Update(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegActualizado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> DeleteCliente(ClienteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Cliente>(entity);

                objContext.Remove(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegEliminado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }
    }
}
