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
        private readonly ApplicationDBContext dbContext;
        public VehicleController(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Vehicle>> AllCars()
        {
            var allCars = VehicleServices.GetVehicles();
            return Ok(allCars);
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int id)
        {
            var vehicleFound = VehicleServices.GetVehicle(id);

            return vehicleFound == null ? NotFound($"Vehicle with id {id} was not found.") : Ok(vehicleFound);
        }

        [HttpPost("add")]
        public ActionResult<Vehicle> AddVehicle([FromBody] VehicleDetails addVehicle)
        { 
            var createdVehicle = VehicleServices.AddVehicle(addVehicle);
            return Ok(createdVehicle);
        }
        [HttpPut("{id}")]
        public ActionResult<Vehicle> UpdateVehicle(int id, VehicleDetails updateVehicle)
        {
            var vehicleToUpdate = VehicleServices.GetVehicle(id);
            if (vehicleToUpdate == null)
                return NotFound("Sorry, we could not find the vehicle to update");
            var updatedVehicle = VehicleServices.UpdateVehicle(updateVehicle, id);
            return Ok(updatedVehicle);
        }
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteVehicle(int id)
        {
            var vehicleToDelete = VehicleServices.GetVehicle(id);
            if (vehicleToDelete == null)
                return NotFound("Sorry, we could not find the vehicle to delete");
            var deletedVehicleResponse = VehicleServices.DeleteVehicle(id);
            return deletedVehicleResponse;
        }
    }
}
