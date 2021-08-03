using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BottomBar.XamarinForms;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BottomBarPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}