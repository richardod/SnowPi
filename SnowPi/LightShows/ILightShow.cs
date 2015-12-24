using SnowPi.Models;

namespace SnowPi.LightShows
{
    public interface ILightShow
    {
        string Name { get; }

        SnowPiLightShowRecording RunLightDisplay(Snowman snowman);
    }
}