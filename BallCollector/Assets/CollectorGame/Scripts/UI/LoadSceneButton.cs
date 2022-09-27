using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

namespace Game.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        public void LoadTargetScene()
        {
            AudioManager.instance.Play("ButtonPress");
            SceneManager.LoadSceneAsync(SceneName);
        }
    }
}
