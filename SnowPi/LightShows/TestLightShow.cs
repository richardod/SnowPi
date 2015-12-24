using SnowPi.Models;

namespace SnowPi.LightShows
{
    public class TestLightShow : ILightShow
    {
        public TestLightShow()
        {
            Name = "Test Light Show";
        }

        public string Name { get; }

        public SnowPiLightShowRecording RunLightDisplay(Snowman snowPi)
        {
            return snowPi
                .Setup()
                .TurnLedOn(Led.LeftBottom) // Turn on
                .PauseForSeconds(1)
                .TurnLedOn(Led.LeftMiddle)
                .PauseForSeconds(1)
                .TurnLedOn(Led.LeftTop)
                .PauseForSeconds(1)
                .TurnLedOn(Led.RightBottom)
                .PauseForSeconds(1)
                .TurnLedOn(Led.RightMiddle)
                .PauseForSeconds(1)
                .TurnLedOn(Led.RightTop)
                .PauseForSeconds(1)
                .TurnLedOn(Led.Nose)
                .PauseForSeconds(1)
                .TurnLedOn(Led.LeftEye)
                .PauseForSeconds(1)
                .TurnLedOn(Led.RightEye)
                .PauseForSeconds(1)
                .TurnLedOn(Led.Nose)
                .PauseForSeconds(5) // Hold for 5 seconds
                .TurnLedOff(Led.LeftBottom) // Turn off
                .PauseForSeconds(1)
                .TurnLedOff(Led.LeftMiddle)
                .PauseForSeconds(1)
                .TurnLedOff(Led.LeftTop)
                .PauseForSeconds(1)
                .TurnLedOff(Led.RightBottom)
                .PauseForSeconds(1)
                .TurnLedOff(Led.RightMiddle)
                .PauseForSeconds(1)
                .TurnLedOff(Led.RightTop)
                .PauseForSeconds(1)
                .TurnLedOff(Led.Nose)
                .PauseForSeconds(1)
                .TurnLedOff(Led.LeftEye)
                .PauseForSeconds(1)
                .TurnLedOff(Led.RightEye)
                .PauseForSeconds(1)
                .TurnLedOff(Led.Nose);
        }
    }
}