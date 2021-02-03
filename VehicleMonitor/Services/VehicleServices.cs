using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleMonitor.Data;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;

namespace VehicleMonitor.Services {

    public class VehicleServices {

        private  ApplicationDBContext dbContext = new ApplicationDBContext();

        public Vehicle AddVehicle(VehicleDetails vehicleDetails) {
            Vehicle vehicle = new Vehicle() {
                Temperature = vehicleDetails.Temperature,
                Humidity = vehicleDetails.Humidity
            };
           
            Vehicle addedVehicle = dbContext.Vehicles.Add(vehicle).Entity;
            dbContext.SaveChanges();
           /// SignalRService.SendSignal(addedVehicle);
            return addedVehicle;
        }

        public List<Vehicle> GetVehicles() {
            List<Vehicle> vehicles = dbContext.Vehicles.ToList();
            return vehicles;
        }

        public Vehicle GetVehicle(int id) {
            Vehicle vehicle = dbContext.Vehicles.Find(id);
            return vehicle;
        }

        public Vehicle UpdateVehicle(VehicleDetails vehicleDetails, int id) {
            Vehicle vehicle = dbContext.Vehicles.Find(id);
            if (vehicle != null) {
                vehicle.Temperature = vehicleDetails.Temperature;
                vehicle.Humidity = vehicleDetails.Humidity;
            }
            dbContext.SaveChanges();
            return vehicle;
        }

        public int DeleteVehicle(int id) {
            Vehicle vehicle = dbContext.Vehicles.Find(id);
            if (vehicle != null) {
                dbContext.Vehicles.Remove(vehicle);
                dbContext.SaveChanges();
                return id;
            }
            return 0;
        }

    }

}
