using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository dashboardRepository;

        public DashboardService(IDashboardRepository _dashboardRepository)
        {
            this.dashboardRepository = _dashboardRepository;
        }

        public Task<Result> GetAllDashboard()
        {
            return dashboardRepository.GetAllDashboard();
        }
    }
}
