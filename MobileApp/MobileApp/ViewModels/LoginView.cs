using System;
using System.Collections.Generic;
using System.Text;
using MobileApp.Models;

namespace MobileApp.ViewModels
{
    public class LoginView
    {
        private LoginViewModel model;
        public LoginViewModel Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public LoginView()
        {
            this.model = new LoginViewModel();
        }
    }
}
