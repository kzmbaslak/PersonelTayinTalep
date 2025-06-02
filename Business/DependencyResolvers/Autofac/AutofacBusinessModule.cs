using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Core.CrossCuttingConcerns.Logging.FileLogger;
using Core.Utilities.Interceptors;
using Core.Utilities.Mappings;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Logging;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CourthouseManager>().As<ICourthouseService>().SingleInstance();
            builder.RegisterType<EfCourthouseDal>().As<ICourthouseDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<TransferRequestManager>().As<ITransferRequestService>().SingleInstance();
            builder.RegisterType<EfTransferRequestDal>().As<ITransferRequestDal>().SingleInstance();

            builder.RegisterType<TransferTypeManager>().As<ITransferTypeService>().SingleInstance();
            builder.RegisterType<EfTransfertTypeDal>().As<ITransferTypeDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


            // AutoMapper Profillerini tara ve yükle
            AutoMapperScanAndInstall(builder);


            //loggers
            builder.RegisterType<FileLogger>().As<ILoggerService>();



            //AOP Interceptor seçicinin belirlenmesi
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }

        private void AutoMapperScanAndInstall(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Assembly'deki tüm profilleri tara
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });
            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
            AutoMapperHelper.Configure(mapper);
            
        }
    }

}