using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.UI.Xaml;
using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using SnowPi.LightShows;
using SnowPi.Services;

namespace SnowPi
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            Window.Current.Activate();
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var deviceInfo = new EasClientDeviceInformation();

            if (DeviceIsRaspberryPi(deviceInfo))
            {
                Container.RegisterType<ISnowPiGPIOControllerService, SnowPiGPIOControllerService>();
            }
            else
            {
                // Assume it a desktop
                Container.RegisterType<ISnowPiGPIOControllerService, SnowPiGPIODebugControllerService>();
            }

            // Registers all LightShows automatically
            Container.RegisterTypes(AllClasses.FromApplication()
                .Where(type => typeof (ILightShow).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.Transient);
            Container.RegisterType<IEnumerable<ILightShow>, ILightShow[]>();


            return base.OnInitializeAsync(args);
        }

        private static bool DeviceIsRaspberryPi(EasClientDeviceInformation deviceInfo)
        {
            return deviceInfo?.SystemProductName.Contains("Raspberry") == true;
        }
    }
}