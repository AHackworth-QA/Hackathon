using System;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Services;
using Xunit;
using Moq;
using VehicleMonitorAPI.Controllers;
using System.Collections.Generic;

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
        public VehicleControllerTest()
        {
            addVehicle = new Mock<VehicleDetails>();
            _addVehicle = new VehicleDetails() { Humidity = 20, Temperature = 15 };

            vehicle = new Mock<VehicleDetails>();
            vehicles = new List<VehicleDetails> { vehicle.Object };

            updateVehicle = new Mock<VehicleDetails>();
            _updateVehicle = new VehicleDetails() { Humidity = 30, Temperature = 40 };


        }
        
        [Fact]
        public void GetVehicle_Test()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
