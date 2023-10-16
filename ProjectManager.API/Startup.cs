using MediatR;
using System.Reflection;

namespace ProjectManager.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddControllers();
        }
    }
}
