using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.DataModels
{
    public class VisitorDataModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int QuestId { get; set; }

        public int ZoneId { get; set; }

        public string CompletedRoute { get; set; }
    }
}
