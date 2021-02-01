using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleMonitor.Models.Entity;

namespace VehicleMonitor.Data {

    public class ApplicationDBContext : DbContext {

        public static string connectionString = "Data Source=.;Initial Catalog=BAEDB;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePos> VehiclePositions { get; set; }

    }

}
