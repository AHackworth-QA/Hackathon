using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleMonitor.Data;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;
using VehicleMonitor.Services;

namespace VehicleMonitorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        VehicleServices vehicleServices = new VehicleServices();
        [HttpGet("all")]
        public ActionResult<IEnumerable<Vehicle>> AllVehicles()
        {
            var allVehicles = vehicleServices.GetVehicles();
            return Ok(allVehicles);
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int id)
        {
            var vehicleFound = vehicleServices.GetVehicle(id);

            return vehicleFound == null ? NotFound($"Vehicle with id {id} was not found.") : Ok(vehicleFound);
        }

        [HttpPost("add")]
        public ActionResult<Vehicle> AddVehicle([FromBody] VehicleDetails addVehicle)
        { 
            var createdVehicle = vehicleServices.AddVehicle(addVehicle);
            return Ok(createdVehicle);
        }

        [HttpPut("{id}")]
        public ActionResult<Vehicle> UpdateVehicle(int id, VehicleDetails updateVehicle)
        {
            var vehicleToUpdate = vehicleServices.GetVehicle(id);
            if (vehicleToUpdate == null)
                return NotFound($"Vehicle with id {id} was not found.");
            var updatedVehicle = vehicleServices.UpdateVehicle(updateVehicle, id);
            return Ok(updatedVehicle);
        }
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteVehicle(int id)
        {
            var vehicleToDelete = vehicleServices.GetVehicle(id);
            if (vehicleToDelete == null)
                return NotFound($"Vehicle with id {id} was not found.");
            var deletedVehicleResponse = vehicleServices.DeleteVehicle(id);
            return deletedVehicleResponse;
        }
    }
}
