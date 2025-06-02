using Business.Concrete;
using ConsoleUI.IoC;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<App>(); // Uygulamanın giriş noktası
        }
        static void Main(string[] args)
        {
            // DI container kurulumu
            var serviceCollection = new ServiceCollection();

            // Servisleri kaydet
            ConfigureServices(serviceCollection);

            // ServiceProvider oluştur
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Uygulamanı başlat
            var app = serviceProvider.GetService<App>();
            app.Run();






            //CityTest();
            //CourthouseTest();
            TransferRequestTest();
        }

        private static void TransferRequestTest()
        {
            TransferRequestManager transferRequestManager = new TransferRequestManager(new EfTransferRequestDal());
            foreach (var transferRequest in transferRequestManager.GetAllTransferRequestDetails().Data)
            {
                Console.WriteLine($"{transferRequest.Id} {transferRequest.TransferTypeName} {transferRequest.User.FirstName} {transferRequest.RequestDate} ");
            }
        }

        private static void CourthouseTest()
        {
            Console.WriteLine("Courthouse Listesi:");
            CourthouseManager courthouseManager = new CourthouseManager(new EfCourthouseDal());
            foreach (var courthouse in courthouseManager.GetAll().Data)
            {
                Console.WriteLine($"{courthouse.Id} {courthouse.Name} {courthouse.CityId}");
            }
        }

        private static void CityTest()
        {
            var cityManager = new CityManager(new EfCityDal()); // Simplified 'new' expression (IDE0090)
            foreach (var city in cityManager.GetAll().Data)
            {
                Console.WriteLine($"{city.Id} {city.Name}");
            }
        }
    }
}