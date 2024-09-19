using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IBackOfficeRepository
    {
        Task<Result> ValidarLogin(LoginModel objModel);
        Task<Result> Registro(LoginModel objModel);
        Task<Result> RegistroAdmin(LoginModel objModel);
        Task<Result> CambioPassword(ChangePasswordModel objModel);
    }
}
