using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobileMixMashup
{
    public class SimpleSceneLoader : MonoBehaviour
    {
        public void LoadSceneByName(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
