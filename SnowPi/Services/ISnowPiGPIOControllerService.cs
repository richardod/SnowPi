using SnowPi.Models;

namespace SnowPi.Services
{
    public interface ISnowPiGPIOControllerService
    {
        void ToggleLed(Led led, bool turnOn);
    }
}