using System.Data.Common;
using System.Data.SqlClient;
using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Repository.EngineerRepository;
using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Repository.UnitOfWork;

namespace Amigo.BAU.API.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IDateTimeProvider), typeof(DateTimeProvider));
            services.AddSingleton(typeof(ISupportTeam), typeof(SupportTeam));
            services.AddScoped(typeof(IEngineerRepository), typeof(EngineerRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(ISupportWheelOfFate), typeof(SupportWheelOfFateService));
        }
    }
}
