using System.Diagnostics;
using SnowPi.Models;

namespace SnowPi.Services
{
    public class SnowPiGPIODebugControllerService : ISnowPiGPIOControllerService
    {
        public void ToggleLed(Led led, bool turnOn)
        {
            Debug.WriteLine($"Led {led} has value {turnOn}");
        }
    }
}