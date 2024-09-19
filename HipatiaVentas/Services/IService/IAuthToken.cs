using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IAuthToken
    {
        string GenerarToken(AuthModel authModel);
    }
}
