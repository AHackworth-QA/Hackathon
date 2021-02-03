using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMonitorAPI.Hubs
{
    public class VehicleHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "App Users");
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "App Users");
            await base.OnDisconnectedAsync(exception);
        }
        public async Task NewAlert()
        {
            await Clients.All.SendAsync("Data Added.");
        }
    }
}