using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamWebApiClient.ViewModels;
using XamWebApiClient.Views;

namespace XamWebApiClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddBook), typeof(AddBook));
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
        }
    }
}
