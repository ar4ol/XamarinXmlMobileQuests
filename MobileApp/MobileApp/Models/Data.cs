using System;
using System.Collections.Generic;
using MobileApp.Models.DataModels;
using MobileApp.Views;

namespace MobileApp.Models
{
    public static class Data
    {
        public static VisitorDataModel VisitorDataModel { get; set; }
        public static Visitor Visitor { get; set; }
        public static MainPage Main { get; set; }
        public static string Route { get; set; }
        public static string CompletedRoute { get; set; }
        public static List<Zone> Zones { get; set; } = new List<Zone>() { };
    }
}
