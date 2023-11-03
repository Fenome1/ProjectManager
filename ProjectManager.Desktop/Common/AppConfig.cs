using Autofac;
using ProjectManager.Desktop.Common.Modules;

namespace ProjectManager.Desktop.Common;

public static class AppConfig
{
    static AppConfig()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<AppModule>();
        Container = builder.Build();
    }

    public static IContainer Container { get; }
}