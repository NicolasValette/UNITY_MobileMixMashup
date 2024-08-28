using System;

namespace MobileMixMashup
{
    public enum EGame
    {
        HexaSort,

        Unknown
    }

    [Serializable]
    public class GameInfo
    {
        public EGame Game { get; set; }
        public string SettingsSceneName { get; set; }
        public string GameSceneName { get; set; }

        public static EGame GameByName(string name)
        {
            if (Enum.TryParse<EGame>(name, out var resGame))
                return resGame;
            return EGame.Unknown;
        }
    }
}
