using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleMonitor.Models.Entity {

    public class VehicleGPS {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Time { get; set; }
    }

}
