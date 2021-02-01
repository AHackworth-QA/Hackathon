using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleMonitor.Models.Binding {

    class VehicleGPSDetails {
        public int VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Time { get; set; }
    }

}
