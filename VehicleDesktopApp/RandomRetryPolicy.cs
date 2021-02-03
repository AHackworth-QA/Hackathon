using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace VehicleDesktopApp
{
    public class RandomRetryPolicy : IRetryPolicy
    {
        private readonly Random _random = new Random();

        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            if(retryContext.ElapsedTime < TimeSpan.FromSeconds(60))
            {
                return TimeSpan.FromSeconds(_random.NextDouble() * 10);
            }
            else
            {
                return null;
            }
        }
    }
    }



