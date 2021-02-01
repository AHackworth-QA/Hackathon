using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleMonitor.Models.Entity {

    public class VehiclePos {

        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Time { get; set; }

        public Vehicle Vehicle { get; set; }

    }

}
