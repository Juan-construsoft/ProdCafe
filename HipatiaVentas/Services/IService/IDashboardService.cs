using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IDashboardService
    {
        Task<Result> GetAllDashboard();
    }
}
