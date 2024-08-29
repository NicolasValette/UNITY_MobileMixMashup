using System;

namespace MobileMixMashup
{
    public enum EGame
    {
        Unknown,

        HexaSort,
    }

    [Serializable]
    public struct GameInfo
    {
        public EGame Game;
        public string SettingsSceneName;
        public string GameSceneName;

        public static EGame GameByName(string name)
        {
            if (Enum.TryParse<EGame>(name, out var resGame))
                return resGame;
            return EGame.Unknown;
        }
    }
}
