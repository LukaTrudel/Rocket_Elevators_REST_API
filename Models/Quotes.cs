using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public partial class Quotes
    {
        public long id { get; set; }
        public string type_building { get; set; }
        public int? numApartment { get; set; }
        public int? numFloor { get; set; }

        public int? numOccupant { get; set; }

        public int? numElevator { get; set; }
        
        public int? totalElevatorPrice { get; set; }
        public int? installationFees { get; set; }
        public int? total { get; set; }
        public string compagnyName { get; set; }
        public string email { get; set; }
    }
}