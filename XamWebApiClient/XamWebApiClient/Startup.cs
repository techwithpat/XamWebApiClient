using Microsoft.Extensions.DependencyInjection;
using System;
using XamWebApiClient.Services;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IBookService, ApiBookService>(c => 
            {
                c.BaseAddress = new Uri("http://10.0.2.2:52236/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<BooksViewModel>();
            services.AddTransient<AddBookViewModel>();
            services.AddTransient<BookDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
