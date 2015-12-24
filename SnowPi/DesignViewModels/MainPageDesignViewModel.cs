using System.Windows.Input;
using SnowPi.Models;

namespace SnowPi.DesignViewModels
{
    public class MainPageDesignViewModel
    {
        public MainPageDesignViewModel()
        {
            SnowPi = new Snowman
            {
                [Led.One] = true,
                [Led.Three] = true,
                [Led.Five] = true,
                [Led.Seven] = true,
                [Led.Nine] = true
            };
        }

        public Snowman SnowPi { get; }

        public ICommand ChangeLightDisplayCommand { get; }

        public string Information => "Tap the hat to change the lightshow!";
    }
}