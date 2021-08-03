using System;
using MobileApp.Models;
using MobileApp.Models.UserModels;
using MobileApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private ApiServices api;
        public RegisterPage()
        {
            api = new ApiServices();
            InitializeComponent();
            var r = new RegisterVisitor();
            dataForm.DataObject = r;
        }

        private async void Registerus(object sender, EventArgs e)
        {
            /*
            if (!dataForm.Validate())
            {
                Reset.IsVisible = true;
                return;
            }*/
            RegisterVisitor rem = (RegisterVisitor)dataForm.DataObject;
            var res = await api.RegisterVisitorAsync(rem);
            if (res)
            {
                await DisplayAlert("Notifications", $@"Registration success!", "OK");
                Reset.IsVisible = false;
                var next = new Login();
                await this.Navigation.PushModalAsync(next);
            }
            else Reset.IsVisible = true;
        }

        private void MoveToLogin(object sender, EventArgs e)
        {
            var next = new Login();
            this.Navigation.PushModalAsync(next);
        }
    }
}