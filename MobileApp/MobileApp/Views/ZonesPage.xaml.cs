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
    public partial class ProjectPage : ContentPage
    {
        private ApiServices api;
        public List<Zone> Zones { get; set; }
        public string Route { get; set; }
        public string CompletedRoute { get; set; }
        public string ourZone { get; set; }
        public ProjectPage()
        {
            api = new ApiServices();
            InitializeComponent();
            Zones = Data.Zones;
            Zone myZone = Zones.Find(x => x.Id == Data.VisitorDataModel.ZoneId);
            if(myZone == null)
            {
                ourZone = "You aren't at any zone";
                
            }
            else
            {
                ourZone = "You're at zone: " + myZone.Name;
                Data.Route = Data.Route.Substring(1, Data.Route.Length - 1);
            }
            Route = "Route: " + Data.Route;
            BindingContext = this;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Zone;
            if (item == null)
                return;
            await Navigation.PushAsync(new TransportInfoPage(item.Id));
            ItemsListView.SelectedItem = null;
        }
    }
}