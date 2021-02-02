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
    public class VehiclePosController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public VehiclePosController(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<VehiclePos>> AllVehiclesPos(int id)
        {
            var allVehicles = VehiclePosServices.GetVehiclePositions(id);
            return Ok(allVehicles);
        }

        [HttpGet("{id}")]
        public ActionResult<VehiclePos> GetVehiclePos(int id)
        {
            var vehicleFound = VehiclePosServices.GetVehiclePosition(id);

            return vehicleFound == null ? NotFound($"Vehicle with id {id} was not found.") : Ok(vehicleFound);
        }

        [HttpPost("add")]
        public ActionResult<VehiclePos> AddVehiclePos([FromBody] VehiclePosDetails addVehicle)
        {
            var createdVehicle = VehiclePosServices.AddVehiclePosition(addVehicle);
            return Ok(createdVehicle);
        }

        [HttpPut("{id}")]
        public ActionResult<VehiclePos> UpdateVehiclePos(int id, VehiclePosDetails updateVehicle)
        {
            var vehicleToUpdate = VehiclePosServices.GetVehiclePosition(id);
            if (vehicleToUpdate == null)
                return NotFound($"Vehicle with id {id} was not found.");
            var updatedVehicle = VehiclePosServices.UpdateVehiclePosition(updateVehicle, id);
            return Ok(updatedVehicle);
        }
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteVehiclePos(int id)
        {
            var vehicleToDelete = VehiclePosServices.GetVehiclePosition(id);
            if (vehicleToDelete == null)
                return NotFound($"Vehicle with id {id} was not found.");
            var deletedVehicleResponse = VehiclePosServices.DeleteVehiclePosition(id);
            return deletedVehicleResponse;
        }
    }
}
