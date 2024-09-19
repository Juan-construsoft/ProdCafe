using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class BackOfficeService : IBackOfficeService
    {
        private readonly IBackOfficeRepository objRepository;

        public BackOfficeService(IBackOfficeRepository _objRepository)
        {
            this.objRepository = _objRepository;
        }

        Task<Result> IBackOfficeService.ValidarLogin(LoginModel loginModel)
        {
            return objRepository.ValidarLogin(loginModel);
        }

        public Task<Result> Registro(LoginModel objModel)
        {
            return objRepository.Registro(objModel);
        }

        public Task<Result> CambioPassword(ChangePasswordModel objModel)
        {
            return objRepository.CambioPassword(objModel);
        }
    }
}
