using System;
using System.Collections.Generic;
using Windows.Devices.Gpio;
using SnowPi.Models;

namespace SnowPi.Services
{
    public class SnowPiGPIOControllerService : ISnowPiGPIOControllerService
    {
        private readonly Dictionary<Led, GpioPin> _gpioPins;

        public SnowPiGPIOControllerService()
        {
            var gpioController = GpioController.GetDefault();

            if (gpioController == null)
            {
                throw new NotSupportedException("GPIO not supported on this device");
            }

            _gpioPins = new Dictionary<Led, GpioPin>
            {
                [Led.LeftEye] = gpioController.OpenPin(23),
                [Led.RightEye] = gpioController.OpenPin(24),
                [Led.Nose] = gpioController.OpenPin(25),
                [Led.LeftTop] = gpioController.OpenPin(16),
                [Led.LeftMiddle] = gpioController.OpenPin(12),
                [Led.LeftBottom] = gpioController.OpenPin(5),
                [Led.RightTop] = gpioController.OpenPin(17),
                [Led.RightMiddle] = gpioController.OpenPin(18),
                [Led.RightBottom] = gpioController.OpenPin(22)
            };

            foreach (var led in _gpioPins.Keys)
            {
                ToggleLed(led, false);
                _gpioPins[led].SetDriveMode(GpioPinDriveMode.Output);
            }
        }

        public void ToggleLed(Led led, bool turnOn)
        {
            _gpioPins[led].Write(turnOn ? GpioPinValue.High : GpioPinValue.Low);
        }
    }
}