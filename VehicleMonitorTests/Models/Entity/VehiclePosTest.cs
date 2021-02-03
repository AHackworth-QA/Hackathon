using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Entity;

namespace VehicleMonitorTests.Models.Entity {

    [TestClass]
    class VehiclePosTest {

        [TestMethod]
        public void CreateVehiclePosTest() {
            DateTime time = DateTime.Now;
            VehiclePos vehiclePos = new VehiclePos() {
                Longitude = -10,
                Latitude = 10,
                Time = time
            };
            Assert.AreEqual(vehiclePos.Longitude, -10);
            Assert.AreEqual(vehiclePos.Latitude, 10);
            Assert.AreEqual(vehiclePos.Time, time);
        }

        [TestMethod]
        public void VehicleTest1() {
            VehiclePos vehiclePos = new VehiclePos();
            Assert.IsNull(vehiclePos.Vehicle);
        }

        [TestMethod]
        public void VehicleTest2() {
            VehiclePos vehiclePos = new VehiclePos() {
                Vehicle = new Vehicle()
            };
            Assert.IsNotNull(vehiclePos.Vehicle);
        }

    }

}
