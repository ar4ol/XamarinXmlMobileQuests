using MobileApp.Models;
using MobileApp.Models.DataModels;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransportInfoPage : ContentPage
    {
        private Zone zoneInfo;
        private string name;
        private ApiServices api;

        public TransportInfoPage(int itemId)
        {
            api = new ApiServices();
            
            InitializeComponent();
            
            zoneInfo = Data.Zones.Find(x => x.Id == itemId);
            name = zoneInfo.Name;
            BindingContext = this;
        }

        private async void ZoneEnter(object sender, EventArgs e)
        {         
            
            await DisplayAlert("Notifications", $@"Success! Now you are at zone: {zoneInfo.Name}", "OK");
            await api.ZoneEnter(zoneInfo.Id);
            var next = new ProjectPage();
            await this.Navigation.PushModalAsync(next);
        }
    }
}