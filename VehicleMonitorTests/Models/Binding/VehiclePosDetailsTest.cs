using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Binding;

namespace VehicleMonitorTests.Models.Binding {

    [TestClass]
    class VehiclePosDetailsTest {

        [TestMethod]
        public void createVehiclePosDetailsTest() {
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                Longitude = 7,
                Latitude = 9
            };
            Assert.AreEqual(vehiclePosDetails.Longitude, 7);
            Assert.AreEqual(vehiclePosDetails.Latitude, 9);
        }

    }

}
