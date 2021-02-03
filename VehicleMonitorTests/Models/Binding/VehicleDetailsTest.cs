using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Binding;

namespace VehicleMonitorTests.Models.Binding {

    [TestClass]
    class VehicleDetailsTest {

        [TestMethod]
        public void createVehicleDetailsTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 15,
                Humidity = 5
            };
            Assert.AreEqual(vehicleDetails.Temperature, 15);
            Assert.AreEqual(vehicleDetails.Humidity, 5);
        }

    }

}
