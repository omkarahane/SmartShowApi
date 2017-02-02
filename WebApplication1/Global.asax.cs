using Autofac;
using Autofac.Integration.WebApi;
using SmartShow.DTO;
using SmartShow.DTO.Repository;
using SmartShow.Service.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        static DataContext instance = new DataContext();
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IContainer container;
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly()); //registed controllers
            
            //builder.RegisterWebApiFilterProvider(config); //register http configuration
            //builder.Register(c => new DataBaseFactory(instance)).As<IDataBaseFactory>().AsImplementedInterfaces();
            builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>().AsImplementedInterfaces().InstancePerRequest();

            
            builder.RegisterType<AllowedFileTypesService>().As<IAllowedFileTypesService>().InstancePerApiRequest();
            builder.RegisterType<AllowedFileTypeRepository>().As<IAllowedFileTypeRepository>().InstancePerApiRequest();
            builder.RegisterType<FileRepository>().As<IFileRepository>().InstancePerApiRequest();
            builder.RegisterType<FileService>().As<IFileService>().InstancePerApiRequest();

            //IContainer container = containerBuilder.Build();
            // GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
