using System;
using System.Collections.Generic;
using System.Text;
using MobileApp.Models;
using MobileApp.Models.UserModels;

namespace MobileApp.ViewModels
{
    public class RegisterView
    {
        private RegisterVisitor model;
        public RegisterVisitor Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public RegisterView()
        {
            this.model = new RegisterVisitor();
        }
    }
}
