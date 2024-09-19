using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IDashboardRepository
    {
        Task<Result> GetAllDashboard();
    }
}
