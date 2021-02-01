using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleMonitor.Models.Entity {

    public class Vehicle {

        public int Id { get; set; }

        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public ICollection<VehiclePos> Positions { get; set; }

    }

}
