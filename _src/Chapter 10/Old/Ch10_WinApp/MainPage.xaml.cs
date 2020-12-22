using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ch10_WinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51564/");
            HttpResponseMessage response = await client.GetAsync("api/shippers");
            DataContext = await response.Content.ReadAsAsync<Shipper[]>();
        }
    }
}
