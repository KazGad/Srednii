using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XTA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommetsPage : ContentPage
    {
        public Hotel CurrentHotel { get; set; }
        public HotelComment CurrentComment { get; set; }
        public CommetsPage(Hotel currentHotel)
        {
            InitializeComponent();

            CurrentHotel = currentHotel;
            CurrentComment.HotelId = currentHotel.Id;
            BindingContext = this;

            UpdateComments();
        }

        private void UpdateComments()
        {
            var client = new WebClient();
            var response = client.DownloadString("http://localhost:53329/api/getHotelComments?hotelId=" +CurrentHotel.Id);
            LViewComments.ItemsSource = JsonConvert.DeserializeObject<List<HotelComment>>(response);
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var result = client.UploadString("http://localhost:53329/api/hotelComments", JsonConvert.SerializeObject(CurrentComment));
            UpdateComments();
        }
    }
}