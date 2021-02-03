using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;
using VehicleMonitor.Services;

namespace VehicleMonitorTests.Services {

    [TestClass]
    class VehicleServicesTest {

        private VehicleServices Services = new VehicleServices();

        [TestMethod]
        public void AddVehicleTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle.Temperature, 10);
            Assert.AreEqual(vehicle.Humidity, 20);
        }

        [TestMethod]
        public void GetVehiclesTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle vehicle1 = Services.AddVehicle(vehicleDetails);
            vehicleDetails = new VehicleDetails() {
                Temperature = 20,
                Humidity = 30
            };
            Vehicle vehicle2 = Services.AddVehicle(vehicleDetails);
            List<Vehicle> vehicles = Services.GetVehicles();
            Assert.IsNotNull(vehicles);
            Assert.IsTrue(vehicles.Contains(vehicle1));
            Assert.IsTrue(vehicles.Contains(vehicle2));
        }

        [TestMethod]
        public void GetVehicleTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle addedVehicle = Services.AddVehicle(vehicleDetails);
            Vehicle vehicle = Services.GetVehicle(addedVehicle.Id);
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle, addedVehicle);
        }

        [TestMethod]
        public void GetVehicleTest2() {
            Vehicle vehicle = Services.GetVehicle(-1);
            Assert.IsNull(vehicle);
        }

        [TestMethod]
        public void UpdateVehicleTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle addedVehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(addedVehicle);
            vehicleDetails = new VehicleDetails() {
                Temperature = 100,
                Humidity = 200
            };
            Vehicle updatedVehicle = Services.UpdateVehicle(vehicleDetails, addedVehicle.Id);
            Assert.IsNotNull(updatedVehicle);
            Assert.AreEqual(addedVehicle.Id, updatedVehicle.Id);
            Assert.AreEqual(updatedVehicle.Temperature, 100);
            Assert.AreEqual(updatedVehicle.Humidity, 200);
        }

        [TestMethod]
        public void UpdateVehicleTest2() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle vehicle = Services.UpdateVehicle(vehicleDetails, -1);
            Assert.IsNull(vehicle);
        }

        [TestMethod]
        public void DeleteVehicleTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 10,
                Humidity = 20
            };
            Vehicle addedVehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(addedVehicle);
            int vehicleId = Services.DeleteVehicle(addedVehicle.Id);
            Assert.AreEqual(addedVehicle.Id, vehicleId);
            Vehicle vehicle = Services.GetVehicle(addedVehicle.Id);
            Assert.IsNull(vehicle);
        }

        [TestMethod]
        public void DeleteVehicleTest2() {
            int vehicleId = Services.DeleteVehicle(-1);
            Assert.AreEqual(vehicleId, 0);
        }

    }

}
