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
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger createLogger;
        private readonly IMapper mapper;

        public ProveedorRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger _createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            this.createLogger = _createLogger;
        }

        public async Task<Result> GetAllProveedores()
        {
            Result oRespuesta = new Result();

            List<ProveedorDto> lstTemp = new List<ProveedorDto>();

            try
            {
                lstTemp = await (from p in objContext.Proveedores
                                 join td in objContext.ParametrosGenerales on p.TipoDocumentoId equals td.Id
                                 join tp in objContext.ParametrosGenerales on p.TipoPersonaId equals tp.Id
                                 select new ProveedorDto
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

        public async Task<Result> GetProveedorById(int? Id)
        {
            Result oRespuesta = new Result();

            ProveedorDto objTemp = new ProveedorDto();

            try
            {
                var objResult = await objContext.Proveedores.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();

                if (objResult != null)
                {
                    objTemp = mapper.Map<ProveedorDto>(objResult);

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

        public async Task<Result> InsertProveedor(CrearProveedorDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Proveedor>(entity);

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

        public async Task<Result> UpdateProveedor(ProveedorDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Proveedor>(entity);

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

        public async Task<Result> DeleteProveedor(ProveedorDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Proveedor>(entity);

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
