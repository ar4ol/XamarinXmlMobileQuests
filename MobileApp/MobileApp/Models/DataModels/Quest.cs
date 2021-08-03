using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.DataModels
{
    public class Quest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Route { get; set; }
    }
}
