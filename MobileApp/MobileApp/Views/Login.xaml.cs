using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Models.DataModels;
using MobileApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        private ApiServices api;
        public Login()
        {
            api = new ApiServices();
            InitializeComponent();
            var r = new LoginViewModel();
            dataForm.DataObject = r;
        }

        private async void Loginus(object sender, EventArgs e)
        {
            if (!dataForm.Validate())
            {
                Reset.IsVisible = true;
                return;
            }
            LoginViewModel rem = (LoginViewModel)dataForm.DataObject;
            var res = await api.LoginVisitorAsync(rem);
            if (res)
            {
                Reset.IsVisible = false;
                await api.GetRoute(Data.VisitorDataModel.QuestId);
                await api.GetZones(Data.VisitorDataModel.QuestId);
                var next = new MainPage();
                Data.Main = next;
                await this.Navigation.PushModalAsync(next);
            }
            else Reset.IsVisible = true;
        }

        private void MoveToRegister(object sender, EventArgs e)
        {
            var next = new RegisterPage();
            this.Navigation.PushModalAsync(next);
        }
    }
}