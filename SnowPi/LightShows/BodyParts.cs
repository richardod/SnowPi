using SnowPi.Models;

namespace SnowPi.LightShows
{
    public class BodyParts : ILightShow
    {
        public string Name => "Body Parts";

        public SnowPiLightShowRecording RunLightDisplay(Snowman snowman)
        {
            return snowman.Setup()
                .TurnLedOn(Led.LeftEye)
                .TurnLedOn(Led.RightEye)
                .TurnLedOn(Led.Nose)
                .PauseForSeconds(3)
                .TurnLedOn(Led.LeftTop)
                .TurnLedOn(Led.LeftMiddle)
                .TurnLedOn(Led.LeftBottom)
                .PauseForSeconds(3)
                .TurnLedOn(Led.RightBottom)
                .TurnLedOn(Led.RightMiddle)
                .TurnLedOn(Led.RightTop);
        }
    }
}