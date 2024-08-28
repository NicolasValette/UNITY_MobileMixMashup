using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobileMixMashup
{
    public class SceneLoader : MonoBehaviour
    {
        public GameInfo[] GameInfos;

        public void LoadSettingsScene(string gameName)
        {
            if (!TryGetInfosFromGameName(gameName, out var gameInfo))
                return;

            SceneManager.LoadScene(gameInfo.SettingsSceneName);
        }

        public void LoadGameScene(string gameName)
        {
            if (!TryGetInfosFromGameName(gameName, out var gameInfo))
                return;

            SceneManager.LoadScene(gameInfo.GameSceneName);
        }

        private bool TryGetInfosFromGameName(string gameName, out GameInfo gameInfo)
        {
            var game = GameInfo.GameByName(gameName);
            if (game == EGame.Unknown)
            {
                Debug.LogError("Cannot handle Unknown game. Check the button setup!");
                gameInfo = null;
                return false;
            }

            gameInfo = GameInfos.FirstOrDefault(gi => gi.Game == game);
            if (gameInfo == null)
            {
                Debug.LogError($"No game info for {game.ToString()}. Check {nameof(SceneLoader)} setup!");
                return false;
            }

            return true;
        }
    }
}
