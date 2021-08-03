using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.DataModels
{
    public class Zone
    {
        public int Id { get; set; }

        public int QuestId { get; set; }

        public string Name { get; set; }

        public int CountPeople { get; set; }
    }
}
