using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;
using VehicleMonitor.Services;

namespace VehicleMonitorTests.Services {

    [TestClass]
    class VehiclePosServicesTest {

        private VehicleServices Services = new VehicleServices();
        private VehiclePosServices PosServices = new VehiclePosServices();

        [TestMethod]
        public void AddVehiclePositionTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePos = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePos);
            Assert.AreEqual(vehiclePos.Id, vehicle.Id);
            Assert.AreEqual(vehiclePos.Longitude, 50);
            Assert.AreEqual(vehiclePos.Latitude, 100);
        }

        [TestMethod]
        public void GetVehiclePositionsTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePos1 = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePos1);
            vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 500,
                Latitude = 1000
            };
            VehiclePos vehiclePos2 = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePos2);
            List<VehiclePos> vehiclePositions = PosServices.GetVehiclePositions(vehicle.Id);
            Assert.IsNotNull(vehiclePositions);
            Assert.IsTrue(vehiclePositions.Contains(vehiclePos1));
            Assert.IsTrue(vehiclePositions.Contains(vehiclePos2));
        }

        [TestMethod]
        public void GetVehiclePositionTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePosAdded = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePosAdded);
            VehiclePos vehiclePos = PosServices.GetVehiclePosition(vehicle.Id);
            Assert.IsNotNull(vehiclePos);
            Assert.AreEqual(vehiclePosAdded, vehiclePos);
        }

        [TestMethod]
        public void GetVehiclePositionTest2() {
            VehiclePos vehiclePos = PosServices.GetVehiclePosition(-1);
            Assert.IsNull(vehiclePos);
        }

        [TestMethod]
        public void UpdateVehiclePositionTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePosAdded = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePosAdded);
            vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 500,
                Latitude = 1000
            };
            VehiclePos vehiclePosUpdated = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePosUpdated);
            Assert.AreEqual(vehiclePosUpdated.Id, vehicle.Id);
            Assert.AreEqual(vehiclePosUpdated.Longitude, 500);
            Assert.AreEqual(vehiclePosUpdated.Latitude, 1000);
        }

        [TestMethod]
        public void UpdateVehiclePositionTest2() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePos = PosServices.UpdateVehiclePosition(vehiclePosDetails, -1);
            Assert.IsNull(vehiclePos);
        }

        [TestMethod]
        public void DeleteVehiclePositionTest() {
            VehicleDetails vehicleDetails = new VehicleDetails() {
                Temperature = 1,
                Humidity = 1
            };
            Vehicle vehicle = Services.AddVehicle(vehicleDetails);
            Assert.IsNotNull(vehicle);
            VehiclePosDetails vehiclePosDetails = new VehiclePosDetails() {
                VehicleId = vehicle.Id,
                Longitude = 50,
                Latitude = 100
            };
            VehiclePos vehiclePosAdded = PosServices.AddVehiclePosition(vehiclePosDetails);
            Assert.IsNotNull(vehiclePosAdded);
            int deletedVehiclePosId = PosServices.DeleteVehiclePosition(vehiclePosAdded.Id);
            Assert.AreEqual(deletedVehiclePosId, vehiclePosAdded.Id);
            VehiclePos vehiclePos = PosServices.GetVehiclePosition(vehiclePosAdded.Id);
            Assert.IsNull(vehiclePos);
        }

        [TestMethod]
        public void DeleteVehiclePositionTest2() {
            int deletedVehiclePosId = PosServices.DeleteVehiclePosition(-1);
            Assert.AreEqual(deletedVehiclePosId, 0);
        }

    }

}
