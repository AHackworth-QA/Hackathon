using System;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Services;
using Xunit;
using Moq;
using VehicleMonitorAPI.Controllers;
using System.Collections.Generic;
using VehicleMonitor.Models.Entity;
using System.Linq;

namespace VehicleMonitorAPITEST
{
    public class VehiclePosControllerTest
    {
        private VehiclePosController _VehicleController;
        private VehiclePosDetails _addVehicle;
        private VehiclePosDetails _updateVehicle;
        private List<VehiclePosDetails> vehicles;
        private readonly Mock<VehiclePosDetails> addVehicle;
        private readonly Mock<VehiclePosDetails> updateVehicle;
        private readonly Mock<VehiclePosDetails> vehicle;
        private readonly Mock<VehiclePosServices> vehicleService;
        public VehiclePosControllerTest()
        {
            addVehicle = new Mock<VehiclePosDetails>();
            _addVehicle = new VehiclePosDetails() { Longitude = 20, Latitude = 15 };

            vehicle = new Mock<VehiclePosDetails>();
            vehicles = new List<VehiclePosDetails> { vehicle.Object };

            updateVehicle = new Mock<VehiclePosDetails>();
            _updateVehicle = new VehiclePosDetails() { Longitude = 30, Latitude = 40 };

            vehicleService = new Mock<VehiclePosServices>();
        }

        [Fact]
        public void GetVehiclePos()
        {
            //Arrange
            var vehicle1 = new VehiclePos {Longitude = 25.00, Latitude = 35.00};
            vehicleService.Setup(c => c.GetVehiclePosition(It.IsAny<int>())).Returns(vehicle1);
            //Act
            var getVehicleResult = _VehicleController.GetVehiclePos(1);
            //Assert
            Assert.IsType<Vehicle>(getVehicleResult);
        }

        [Fact]
        public void AddVehiclePos()
        {
            //Arrange
            var vehicle1 = new VehiclePos {Longitude = 25.00, Latitude = 30.05 };
            vehicleService.Setup(c => c.AddVehiclePosition(addVehicle.Object)).Returns(vehicle1);
            //Act
            var addVehicleResult = _VehicleController.AddVehiclePos(_addVehicle);
            //Assert
            Assert.IsType<Vehicle>(addVehicleResult);
        }
        [Fact]
        public void GetVehiclesPos()
        {
            //Arrange
            var vehiclesL = new List<VehiclePos>();
            var vehicle1 = new VehiclePos {Id = 1,Longitude = 25.00, Latitude = 30.05 };
            var vehicle2 = new VehiclePos {Id = 1,Longitude = 35.00, Latitude = 40.05 };

            vehiclesL.Add(vehicle1);
            vehiclesL.Add(vehicle2);

            vehicleService.Setup(c => c.GetVehiclePositions(1)).Returns(vehiclesL);
            //Act
            var getVehiclesResult = _VehicleController.GetVehiclePos(1);
            //Assert
            Assert.IsType<List<VehiclePos>>(getVehiclesResult);
        }
        [Fact]
        public void UpdateVehiclePos()
        {
            //Arrange
            var vehicle1 = new VehiclePos {Longitude = 25.00, Latitude = 30.05 };
            vehicleService.Setup(c => c.UpdateVehiclePosition(updateVehicle.Object, It.IsAny<int>())).Returns(vehicle1);
            //Act
            var updateVehicleResult = _VehicleController.UpdateVehiclePos(vehicle1.Id, _updateVehicle);
            //Assert
            Assert.IsType<Vehicle>(updateVehicleResult);
        }
        [Fact]
        public void DeleteVehiclePos()
        {
            //Arrange
            vehicleService.Setup(c => c.DeleteVehiclePosition(It.IsAny<int>()));
            //Act
            _VehicleController.DeleteVehiclePos(1);
        }
    }
}
