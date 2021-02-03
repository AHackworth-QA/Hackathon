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
    public class VehicleControllerTest
    {
        private VehicleController _VehicleController;
        private VehicleDetails _addVehicle;
        private VehicleDetails _updateVehicle;
        private List<VehicleDetails> vehicles;
        private readonly Mock<VehicleDetails> addVehicle;
        private readonly Mock<VehicleDetails> updateVehicle;
        private readonly Mock<VehicleDetails> vehicle;
        private readonly Mock<VehicleServices> vehicleService;
        public VehicleControllerTest()
        {
            addVehicle = new Mock<VehicleDetails>();
            _addVehicle = new VehicleDetails() { Humidity = 20, Temperature = 15 };

            vehicle = new Mock<VehicleDetails>();
            vehicles = new List<VehicleDetails> { vehicle.Object };

            updateVehicle = new Mock<VehicleDetails>();
            _updateVehicle = new VehicleDetails() { Humidity = 30, Temperature = 40 };

            vehicleService = new Mock<VehicleServices>();
        }
        
        [Fact]
        public void GetVehicle()
        {
            //Arrange
            var vehicle1 = new Vehicle { Id = 1, Humidity = 25.00, Temperature = 30.05 };
            vehicleService.Setup(c => c.GetVehicle(It.IsAny<int>())).Returns(vehicle1);
            //Act
            var getVehicleResult = _VehicleController.GetVehicle(1);
            //Assert
            Assert.IsType<Vehicle>(getVehicleResult);
        }

        [Fact]
        public void AddVehicle()
        {
            //Arrange
            var vehicle1 = new Vehicle { Id = 1, Humidity = 25.00, Temperature = 30.05 };
            vehicleService.Setup(c => c.AddVehicle(addVehicle.Object)).Returns(vehicle1);
            //Act
            var addVehicleResult = _VehicleController.AddVehicle(_addVehicle);
            //Assert
            Assert.IsType<Vehicle>(addVehicleResult);
        }
        [Fact]
        public void GetVehicles()
        {
            //Arrange
            var vehiclesL = new List<Vehicle>();
            var vehicle1 = new Vehicle { Id = 1, Humidity = 25.00, Temperature = 30.05 };
            var vehicle2 = new Vehicle { Id = 2, Humidity = 35.00, Temperature = 40.05 };

            vehiclesL.Add(vehicle1);
            vehiclesL.Add(vehicle2);

            vehicleService.Setup(c => c.GetVehicles()).Returns(vehiclesL);
            //Act
            var getVehiclesResult = _VehicleController.AllVehicles();
            //Assert
            Assert.IsType<List<Vehicle>>(getVehiclesResult);
        }
        [Fact]
        public void UpdateVehicle()
        {
            //Arrange
            var vehicle1 = new Vehicle { Id = 1, Humidity = 25.00, Temperature = 30.05 };
            vehicleService.Setup(c => c.UpdateVehicle(updateVehicle.Object, It.IsAny<int>())).Returns(vehicle1);
            //Act
            var updateVehicleResult = _VehicleController.UpdateVehicle(vehicle1.Id, _updateVehicle);
            //Assert
            Assert.IsType<Vehicle>(updateVehicleResult);
        }
        [Fact]
        public void DeleteVehicle()
        {
            //Arrange
            vehicleService.Setup(c => c.DeleteVehicle(It.IsAny<int>()));
            //Act
            _VehicleController.DeleteVehicle(1);
        }
    }
}
