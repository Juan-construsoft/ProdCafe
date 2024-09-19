using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;

namespace HipatiaVentas.Repositories.Repository
{
    public class BackOfficeRepository : IBackOfficeRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly IConfiguration configuration;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper mapper;

        public BackOfficeRepository(ApplicationDbContext _objContext, IConfiguration _configuration, IMapper mapper)
        {
            this.objContext = _objContext;
            this.configuration = _configuration;
            this.mapper = mapper;
        }

        public async Task<Result> ValidarLogin(LoginModel objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var result = (from us in objContext.Users
                              join ur in objContext.UserRoles on us.Id equals ur.UserId
                              join rol in objContext.Roles on ur.RoleId equals rol.Id
                              select new
                              {
                                  us.Id,
                                  us.UserName,
                                  us.Email,
                                  us.PasswordHash,
                                  rol.NormalizedName
                              })
                            .Where(us => us.Email == objModel.Email)
                            .FirstOrDefault();

                if (result != null)
                {
                    PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

                    ApplicationUser applicationUser = new ApplicationUser()
                    {
                        UserName = result.UserName,
                        Email = result.Email,
                        PasswordHash = result.PasswordHash
                    };

                    var vValida = passwordHasher.VerifyHashedPassword(applicationUser, result.PasswordHash, objModel.Password);

                    if (vValida.ToString() == "Success")
                    {
                        UsuarioLoginDto model = new UsuarioLoginDto();
                        {
                            model.Id = result.Id;
                            model.UserName = result.UserName;
                            model.Email = result.Email;
                            model.Rol = result.NormalizedName;
                        };

                        oRespuesta.Success = true;
                        oRespuesta.Data = model;
                    }
                    else
                    {
                        oRespuesta.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        //public async Task<Result> Registro(LoginModel objModel)
        //{
        //    Result oRespuesta = new Result();

        //    try
        //    {
        //        var userExists = await userManager.FindByEmailAsync(objModel.Email);

        //        if (userExists != null)
        //        {
        //            oRespuesta.Success = false;
        //            oRespuesta.Message = Constantes.msjUsuarioEstaRegistrado;
        //        }
        //        else
        //        {
        //            ApplicationUser user = new()
        //            {
        //                Email = objModel.Email,
        //                SecurityStamp = Guid.NewGuid().ToString(),
        //                UserName = objModel.UserName,
        //            };

        //            var result = await userManager.CreateAsync(user, objModel.Password);

        //            if (!result.Succeeded)
        //            {
        //                oRespuesta.Success = false;
        //                oRespuesta.Message = Constantes.msjUsuarioNoGuardado;
        //            }
        //            else
        //            {
        //                oRespuesta.Success = true;
        //                oRespuesta.Message = Constantes.msjUsuarioGuardado;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _createLogger.LogWriteExcepcion(ex.Message);

        //        oRespuesta.Message = ex.Message;
        //    }

        //    return oRespuesta;
        //}

        //public async Task<Result> CambioPassword(ChangePasswordModel objModel)
        //{
        //    Result oRespuesta = new Result();

        //    try
        //    {
        //        var user = await userManager.FindByEmailAsync(objModel.Email);

        //        if (user == null)
        //        {
        //            oRespuesta.Success = false;
        //            oRespuesta.Message = Constantes.msjNoHayRegistros;
        //        }
        //        else if (string.Compare(objModel.NewPassword, objModel.ConfirmNewpassword) != 0)
        //        {
        //            oRespuesta.Success = false;
        //            oRespuesta.Message = Constantes.msjDosPasseordNoIguales;
        //        }
        //        else
        //        {
        //            var result = await userManager.ChangePasswordAsync(user, objModel.CurrentPassword, objModel.NewPassword);

        //            if (!result.Succeeded)
        //            {
        //                oRespuesta.Success = false;
        //                oRespuesta.Message = Constantes.msjNoSepUdoCambiarPass;
        //            }
        //            else
        //            {
        //                oRespuesta.Success = true;
        //                oRespuesta.Message = Constantes.msjPassCambiado;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _createLogger.LogWriteExcepcion(ex.Message);

        //        oRespuesta.Message = ex.Message;
        //    }

        //    return oRespuesta;
        //}

        //public async Task<Result> RegistroAdmin(LoginModel objModel)
        //{
        //    Result oRespuesta = new Result();

        //    try
        //    {
        //        var userExists = await userManager.FindByEmailAsync(objModel.Email);

        //        if (userExists != null)
        //        {
        //            oRespuesta.Success = false;
        //            oRespuesta.Message = Constantes.msjUsuarioEstaRegistrado;
        //        }
        //        else
        //        {
        //            ApplicationUser user = new()
        //            {
        //                Email = objModel.Email,
        //                SecurityStamp = Guid.NewGuid().ToString(),
        //                UserName = objModel.UserName,
        //            };

        //            var result = await userManager.CreateAsync(user, objModel.Password);

        //            if (!result.Succeeded)
        //            {
        //                oRespuesta.Success = false;
        //                oRespuesta.Message = Constantes.msjUsuarioNoGuardado;
        //            }
        //            else
        //            {
        //                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        //                if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //                    await userManager.AddToRoleAsync(user, UserRoles.Admin);

        //                oRespuesta.Success = true;
        //                oRespuesta.Message = Constantes.msjUsuarioGuardado;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _createLogger.LogWriteExcepcion(ex.Message);

        //        oRespuesta.Message = ex.Message;
        //    }

        //    return oRespuesta;
        //}




        public Task<Result> CambioPassword(ChangePasswordModel objModel)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Registro(LoginModel objModel)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RegistroAdmin(LoginModel objModel)
        {
            throw new NotImplementedException();
        }

        //public Task<Result> ValidarLogin(LoginModel objModel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
