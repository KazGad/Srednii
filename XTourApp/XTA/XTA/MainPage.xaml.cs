using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XTA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://localhost:53329/api/hotels");
            LviewHotels.ItemsSource = JsonConvert.DeserializeObject<List<Hotel>>(response);
        }

        private void LviewHotels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CommetsPage(LviewHotels.SelectedItem as Hotel));
        }
    }
}
