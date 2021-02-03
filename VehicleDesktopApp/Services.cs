using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleMonitor.Models.Binding;
using VehicleMonitor.Models.Entity;

namespace VehicleDesktopApp
{
    public class Services
    {
        private static string BaseUrl = "https://localhost:44342/api/";
        internal async static Task<List<Vehicle>> AllVehicles()
        {
            var allVehiclesUrl = $"{BaseUrl}vehicle/all";
            using (HttpClient httpClient = new HttpClient())
            {
                var allVehicleResponse = await httpClient.GetStringAsync(allVehiclesUrl);
                var allVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(allVehicleResponse);
                return allVehicles;
            }
        }

        internal async static Task<Vehicle> UpdateVehicle(VehicleDetails vehicleUpdateModel, int Id)
        {
            var updateVehicleUrl = $"{BaseUrl}vehicle/{Id}";
            using (HttpClient httpClient = new HttpClient())
            {
                var url = new Uri(updateVehicleUrl);
                string jsonTransport = JsonConvert.SerializeObject(vehicleUpdateModel);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var updateVehicleResponse = await httpClient.PutAsync(url, jsonPayload);
                var responseContent = await updateVehicleResponse.Content.ReadAsStringAsync();
                var updatedVehicle = JsonConvert.DeserializeObject<Vehicle>(responseContent);
                return updatedVehicle;

                
                


            }
        }



        internal async static Task<string> DeleteVehicle(int Id)
        {
            var deleteVehicleUrl = $"{BaseUrl}vehicle/{Id}";
            using (HttpClient httpClient =new HttpClient())
            {
                var vehicleDeleteResponse = await httpClient.DeleteAsync(deleteVehicleUrl);
                var responseContent = await vehicleDeleteResponse.Content.ReadAsStringAsync();
                return responseContent;

            }
        }
        internal static async Task<Vehicle> AddVehicle(VehicleDetails vehicleAddModel)
        {
            var addVehicleUrl = $"{BaseUrl}vehicle/add"; 
            using (HttpClient httpClient = new HttpClient())
            {
                var url = new Uri(addVehicleUrl);
                string jsonTranport = JsonConvert.SerializeObject(vehicleAddModel);
                var jsonPayload = new StringContent(jsonTranport, Encoding.UTF8, "application/json");
                var updateCarResponse = await httpClient.PostAsync(url, jsonPayload);
                var responseContent = await updateCarResponse.Content.ReadAsStringAsync();
                var updatedVehicle = JsonConvert.DeserializeObject<Vehicle>(responseContent);
                return updatedVehicle;
            }
        }
    }
}
