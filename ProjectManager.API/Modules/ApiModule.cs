using MediatR;
using System.Reflection;

namespace ProjectManager.API.Modules
{
    public class ApiModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddControllers();
        }
    }
}
