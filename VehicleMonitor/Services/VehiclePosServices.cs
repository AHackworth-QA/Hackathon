using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleMonitor.Data;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;

namespace VehicleMonitor.Services {

    public class VehiclePosServices {

        private static ApplicationDBContext dbContext = new ApplicationDBContext();

        public static VehiclePos AddVehiclePosition(VehiclePosDetails vehiclePosDetails) {
            VehiclePos vehiclePos = new VehiclePos() {
                VehicleId = vehiclePosDetails.VehicleId,
                Longitude = vehiclePosDetails.Longitude,
                Latitude = vehiclePosDetails.Latitude,
                Time = vehiclePosDetails.Time
            };
            VehiclePos addedVehiclePos = dbContext.VehiclePositions.Add(vehiclePos).Entity;
            dbContext.SaveChanges();
            return addedVehiclePos;
        }

        public static List<VehiclePos> GetVehiclePositions(int vehicleId) {
            List<VehiclePos> vehiclePositions = dbContext.VehiclePositions.Where(v => v.VehicleId == vehicleId).ToList();
            return vehiclePositions;
        }

        public static VehiclePos GetVehiclePosition(int id) {
            VehiclePos vehiclePos = dbContext.VehiclePositions.Find(id);
            return vehiclePos;
        }

        public static VehiclePos UpdateVehiclePosition(VehiclePosDetails vehiclePosDetails, int id) {
            VehiclePos vehiclePos = dbContext.VehiclePositions.Find(id);
            if (vehiclePos != null) {
                vehiclePos.VehicleId = vehiclePosDetails.VehicleId;
                vehiclePos.Longitude = vehiclePosDetails.Longitude;
                vehiclePos.Latitude = vehiclePosDetails.Latitude;
                vehiclePos.Time = vehiclePosDetails.Time;
            }
            dbContext.SaveChanges();
            return vehiclePos;
        }

        public static int DeleteVehiclePosition(int id) {
            VehiclePos vehiclePos = dbContext.VehiclePositions.Find(id);
            if (vehiclePos != null) {
                dbContext.VehiclePositions.Remove(vehiclePos);
                dbContext.SaveChanges();
                return id;
            }
            return 0;
        }

    }

}
