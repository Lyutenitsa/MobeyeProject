using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobeyeApplication.MobeyeRESTClient;
using MobeyeApplication.MobeyeRESTClient.JSON_objects;

namespace MobeyeApplication.MobeyeRESTClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmsPage : ContentPage
    {
        public AlarmsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetPrivateKey();
        }

        public async void GetPrivateKey()
        {
            string requestURI = "https://www.api.mymobeye.com/api/registerphone";
            HttpClient client = HttpHelper.CreateClient();

            var regPhone = new RegPhone("bbbb2222", "22222");            
            var responce = await client.PostAsync(requestURI, HttpHelper.ObjectToHttpContent(regPhone));

            var resString = await responce.Content.ReadAsStringAsync();
            List<string> idk = new List<string>();
        }
    }   
}