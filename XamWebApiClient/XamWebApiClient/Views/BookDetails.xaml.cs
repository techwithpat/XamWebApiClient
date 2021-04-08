
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetails : ContentPage
    {
        public BookDetails()
        {
            InitializeComponent();

            BindingContext = Startup.Resolve<BookDetailsViewModel>();
        }
    }
}