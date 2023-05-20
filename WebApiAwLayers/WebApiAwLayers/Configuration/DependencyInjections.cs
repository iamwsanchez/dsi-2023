using AwBll.Implementations.Production;
using AwBll.Interfaces.Production;

namespace WebApiAwLayers.Configuration
{
    public static class DependencyInjections
    {
        public static void AddBll(this IServiceCollection services)
        {
            services.AddScoped<ICategoryBll, CategoryBll>();
        }

    }
}
