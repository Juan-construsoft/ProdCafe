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
    public class ParametroGeneralRepository : IParametroGeneralRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger createLogger;
        private readonly IMapper mapper;

        public ParametroGeneralRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger _createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            this.createLogger = _createLogger;
        }

        public async Task<Result> GetAllParametroGenerales()
        {
            Result oRespuesta = new Result();

            List<ParametroGeneralDto> lstTemp = new List<ParametroGeneralDto>();

            try
            {
                lstTemp = await (from pg in objContext.ParametrosGenerales
                                 join tc in objContext.TipoCategorias on pg.TipoCategoriaId equals tc.Id
                                 select new ParametroGeneralDto
                                 {
                                     Id = pg.Id,
                                     Codigo = pg.Codigo,
                                     Nombre = pg.Nombre,
                                     TipoCategoriaId = pg.TipoCategoriaId,
                                     IsActive = pg.IsActive,
                                     NombreTipoCategoria = tc.Nombre
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

        public async Task<Result> GetParametroGeneralById(int? Id)
        {
            Result oRespuesta = new Result();

            ParametroGeneralDto lstTemp = new ParametroGeneralDto();

            try
            {
                lstTemp = await (from pg in objContext.ParametrosGenerales
                                 join tc in objContext.TipoCategorias on pg.TipoCategoriaId equals tc.Id
                                 where pg.Id == Id
                                 select new ParametroGeneralDto
                                 {
                                     Id = pg.Id,
                                     Codigo = pg.Codigo,
                                     Nombre = pg.Nombre,
                                     TipoCategoriaId = pg.TipoCategoriaId,
                                     IsActive = pg.IsActive,
                                     NombreTipoCategoria = tc.Nombre
                                 }).FirstAsync();

                if (lstTemp != null)
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

        public async Task<Result> InsertParametroGeneral(CrearParametroGeneralDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<ParametroGeneral>(entity);

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

        public async Task<Result> UpdateParametroGeneral(ParametroGeneralDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<ParametroGeneral>(entity);

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

        public async Task<Result> DeleteParametroGeneral(ParametroGeneralDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<ParametroGeneral>(entity);

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

        public async Task<Result> GetParametroGeneralByCategoria(int Id)
        {
            Result oRespuesta = new Result();

            List<ParametroGeneral> listResult = new List<ParametroGeneral>();
            List<ParametroGeneralDto> lstTemp = new List<ParametroGeneralDto>();

            try
            {
                lstTemp = await (from pg in objContext.ParametrosGenerales
                                 join tc in objContext.TipoCategorias on pg.TipoCategoriaId equals tc.Id
                                 where tc.Codigo == Id.ToString()
                                 orderby pg.Nombre
                                 select new ParametroGeneralDto
                                 {
                                     Id = pg.Id,
                                     Codigo = pg.Codigo,
                                     Nombre = pg.Nombre,
                                     TipoCategoriaId = pg.TipoCategoriaId,
                                     IsActive = pg.IsActive
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
    }
}
