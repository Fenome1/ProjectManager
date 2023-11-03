using Autofac;
using AutoMapper;

namespace ProjectManager.Desktop.Common.Modules;

public class AppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(prop => prop.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerDependency();

        builder.Register(ctx => new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }))
            .As<IConfigurationProvider>().SingleInstance();

        builder.Register(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

        /* builder.RegisterAssemblyTypes(ThisAssembly)
             .Where(prop => prop.Name.EndsWith("ViewModel"))
             .AsSelf()
             .InstancePerDependency();*/
    }
}