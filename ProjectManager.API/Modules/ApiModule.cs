using System.Reflection;
using MediatR;

namespace ProjectManager.API.Modules;

public class ApiModule
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddControllers();
    }
}