using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using SnowPi.Extensions;
using SnowPi.LightShows;
using SnowPi.Models;
using SnowPi.Services;

namespace SnowPi.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly ISnowPiGPIOControllerService _snowPiGpioControllerService;
        private SnowPiLightShowRecording _currentLightDisplay;
        private bool _firstShow;
        private string _information;

        public MainPageViewModel(ISnowPiGPIOControllerService snowPiGpioControllerService, Snowman snowPi,
            IEnumerable<ILightShow> lightShows)
        {
            _snowPiGpioControllerService = snowPiGpioControllerService;
            var shows = new LinkedList<ILightShow>(lightShows);
            CurrentShow = shows.First;

            ChangeLightDisplayCommand = new DelegateCommand(ChangeLightDisplay);
            SnowPi = snowPi;
            SnowPi.PropertyChanged += SnowPiOnPropertyChanged;
            Information = "Tap the hat to begin!";
            _firstShow = true;
        }

        public LinkedListNode<ILightShow> CurrentShow { get; set; }

        public string Information
        {
            get { return _information; }
            set { SetProperty(ref _information, value); }
        }

        public ICommand ChangeLightDisplayCommand { get; }

        public Snowman SnowPi { get; }

        private void ChangeLightDisplay()
        {
            if (!_firstShow)
            {
                _currentLightDisplay.CancelShow();
                CurrentShow = CurrentShow.NextOrFirst();
            }
            var show = CurrentShow.Value;
            Information = show.Name;
            _currentLightDisplay = show.RunLightDisplay(SnowPi);
            _firstShow = false;
        }

        private void SnowPiOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var propertyName = propertyChangedEventArgs.PropertyName;
            if (propertyName?.StartsWith("Led") == true)
            {
                var ledName = propertyName
                    .Replace("Led", string.Empty)
                    .Replace("Set", string.Empty);

                var led = (Led) Enum.Parse(typeof (Led), ledName);
                var turnOn = SnowPi[led];
                _snowPiGpioControllerService.ToggleLed(led, turnOn);
            }
        }
    }
}