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
    public class RegistroCatacionRepository : IRegistroCatacionRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger createLogger;
        private readonly IMapper mapper;

        public RegistroCatacionRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger _createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            this.createLogger = _createLogger;
        }

        public async Task<Result> GetAllRegistroCataciones()
        {
            Result oRespuesta = new Result();

            List<RegistroCatacionDto> lstTemp = new List<RegistroCatacionDto>();

            try
            {
                lstTemp = await (from rc in objContext.RegistroCataciones
                                 join v in objContext.ParametrosGenerales on rc.VariedadId equals v.Id
                                 join m in objContext.ParametrosGenerales on rc.MetodoId equals m.Id
                                 select new RegistroCatacionDto
                                 {
                                     Id = rc.Id,
                                     FechaPrueba = rc.FechaPrueba,
                                     Predio = rc.Predio,
                                     Lote = rc.Lote,
                                     VariedadId = rc.VariedadId,
                                     MetodoId = rc.MetodoId,
                                     FraganciaAroma = rc.FraganciaAroma,
                                     Sabor = rc.Sabor,
                                     SaborResidual = rc.SaborResidual,
                                     Acidez = rc.Acidez,
                                     Cuerpo = rc.Cuerpo,
                                     Uniformidad = rc.Uniformidad,
                                     Dulzor = rc.Dulzor,
                                     LimpiezaTaza = rc.LimpiezaTaza,
                                     Balance = rc.Balance,
                                     Global = rc.Global,
                                     Defectos = rc.Defectos,
                                     Puntaje = rc.Puntaje,
                                     IsActive = rc.IsActive
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

        public async Task<Result> GetRegistroCatacionById(int? Id)
        {
            Result oRespuesta = new Result();

            RegistroCatacionDto objTemp = new RegistroCatacionDto();

            try
            {
                var objResult = await objContext.RegistroCataciones.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();

                if (objResult != null)
                {
                    objTemp = mapper.Map<RegistroCatacionDto>(objResult);

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

        public async Task<Result> InsertRegistroCatacion(CrearRegistroCatacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<RegistroCatacion>(entity);

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

        public async Task<Result> UpdateRegistroCatacion(RegistroCatacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<RegistroCatacion>(entity);

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

        public async Task<Result> DeleteRegistroCatacion(RegistroCatacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<RegistroCatacion>(entity);

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
