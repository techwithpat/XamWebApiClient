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
            services.AddSingleton<IBookService, InMemoryBookService>();

            //add viewmodels
            services.AddTransient<BooksViewModel>();
            services.AddTransient<AddBookViewModel>();
            services.AddTransient<BookDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
