using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Entity;

namespace VehicleMonitorTests.Models.Entity {

    [TestClass]
    class VehicleTest {

        [TestMethod]
        public void CreateVehicleTest() {
            Vehicle vehicle = new Vehicle() {
                Id = 1,
                Temperature = 20,
                Humidity = 10
            };
            Assert.AreEqual(1, vehicle.Id);
            Assert.AreEqual(20, vehicle.Temperature);
            Assert.AreEqual(10, vehicle.Humidity);
        }

        [TestMethod]
        public void PositionsTest1() {
            Vehicle vehicle = new Vehicle();
            Assert.IsNull(vehicle.Positions);
        }

        public void PositionsTest2() {
            Vehicle vehicle = new Vehicle() {
                Positions = new List<VehiclePos>()
            };
            Assert.AreEqual(vehicle.Positions.Count, 0);
        }

        public void PositionsTest3() {
            Vehicle vehicle = new Vehicle() {
                Positions = new List<VehiclePos>()
            };
            vehicle.Positions.Add(new VehiclePos());
            Assert.AreEqual(vehicle.Positions.Count, 1);
        }

    }

}
