using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMonitorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private ILogger<VehicleController> _logger;
        private IRepositoryWrapper repository;
        
        public VehicleController(ILogger<VehicleController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            repository = repositoryWrapper;
        }
        //GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<VehicleViewModel> Get()
        {
            var allVehicles = repository.Vehicles.FindAll();
            List<VehicleViewModel> vehicleViewModels = new List<VehicleViewModel>();
            foreach(var vehicle in allVehicles)
            {
                vehicleViewModels.Add(new VehicleViewModel() { Vehicle = vehicle });
            }
            foreach(var vehicleViewModel in vehicleViewModels)
            {
                var vehicleRegistrations = repository.Registrations.FindByCondition(r => r.Vehicle.Id == vehicleViewModel.Vehicle.Id).ToList();
                vehicleViewModel.Humidity = vehicleRegistations.Select(c => c.Humidity).ToList();
                vehicleViewModel.Temp = vehicleRegistations.Select(c => c.Temp).ToList();
                vehicleViewModel.GPS = vehicleRegistations.Select(c => c.GPS).ToList();
            }
            _logger.LogInformation($"{vehicleViewModels.Count} Data Retrieved.");
            return vehicleViewModels;
        }

        //GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public ActionResult<VehicleViewModel> Get(int id)
        {
            var vehicleFound =repository.Vehicles.FindByCondition(c => c.Id == id).FirstOrDefault();
            if (vehicleFound == null)
            {
                _logger.LogWarning($"Vehicle with ID {id} not found.");
                return NotFound($"Course withID {id} not found.");
            }
            _logger.LogInformation($"Course with id {id} found.");
            var vehicles = repository.Registrations.FindByCondition(c => c.Vehicle.Id == id).Select(c => c.Student).ToList(); //NEEDS WORK
            var vehicleFoundViewModel = new VehicleViewModel { Vehicle = vehicleFound, Humidity = humidity, Temp = temp, GPS = gps }; //NEEDS WORK
            return vehicleFoundViewModel;
        }
        
        //POST api/<VehicleController>
        [HttpPost]
        public ActionResult<VehicleViewModel> Post([FromBody] AddVehicle vehicle)
        {
            var existingVehicle = repository.Vehicles.FindByCondition(c => c.Code == course.Code && c.Title == course.Title).FirstOrDefault();
            if(existingVehicle != null)
            {
                _logger.LogError("Data conflict");
                return Conflict("Vehicle already exists.");
            }
            if (string.IsNullOrEmpty(vehicle.Humidity))
            {
                return BadRequest("Vehicle Humidity is empty");
            }
            if (string.IsNullOrEmpty(vehicle.GPS))
            {
                return BadRequest("Vehicle GPS is empty");
            }
            if (string.IsNullOrEmpty(vehicle.Temp))
            {
                return BadRequest("Vehicle Temp is empty");
            }
            var addedVehicle = repository.Vehicles.Create(new Vehicle { Humidity = Vehicle.Humidity, Temperature = Vehicle.Temp, GPS = vehicle.GPS });
            repository.Save();
            return new VehicleViewModel { Vehicle = addedVehicle,}; //NEEDS WORK
        }
        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult<VehicleViewModel> Put(int id, [FromBody] UpdateVehicle vehicle)
        {
            var vehicleToUpdate = repository.Vehicles.FindByCondition(c => c.Id == id).FirstOrDefault();
            if (vehicleToUpdate != null)
            {
                _logger.LogWarning($"Vehicle with ID {id} not found.");
                return NotFound($"Vehicle with ID {id} not found.");
            }
            if (string.IsNullOrEmpty(vehicle.Humidity))
            {
                return BadRequest("Vehicle Humidity is empty");
            }
            if (string.IsNullOrEmpty(vehicle.GPS))
            {
                return BadRequest("Vehicle GPS is empty");
            }
            if (string.IsNullOrEmpty(vehicle.Temp))
            {
                return BadRequest("Vehicle Temp is empty");
            }
            vehicleToUpdate.Humidity = vehicle.Humidity;
            vehicleToUpdate.Temp = vehicle.Temp;
            vehicleToUpdate.GPS = vehicle.GPS;
            repository.Save();
            var studentsInCourse = repository.Registrations.FindByCondition(c => c.Course.Id == id).Select(c => c.Student).ToList(); //NEEDS WORK
            var VehicleFoundViewModel = new VehicleViewModel { Vehicle = VehicleToUpdate, Students = studentsInCourse };
            return vehicleFoundViewModel;
        }
        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vehicleToDelete = repository.Vehicles.FindByCondition(c => c.Id == id).FirstOrDefault();
            if (vehicleToDelete == null)
            {
                _logger.LogWarning($"Vehicle with ID {id} not found.");
                return NotFound($"Vehicle with ID {id} not found.");
            }
            var vehiclesToDelete = repository.Registrations.FindByCondition(c => c.Course.Id == id); //NEEDS WORK
            foreach (var vehicle in vehiclesToDelete)
            {
                repository.Registrations.Delete(vehicle);
                repository.Save();
            }
            _logger.LogCritical($"Deleting vehicle registration for {vehiclesToDelete.Id} completed");
            repository.Vehicles.Delete(vehicleToDelete);
            repository.Save();
            _logger.LogCritical($"deleting {vehiclesToDelete.Id} completed");
            return Ok("Vehicle deleted");
        }
    }
}
