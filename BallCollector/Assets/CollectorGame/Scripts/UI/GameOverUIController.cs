using TMPro;
using UnityEngine;


namespace Game.UI
{
    /// <summary>
    /// A MonoBehaviour for controlling the UI of the game scene.
    /// </summary>
    public class GameOverUIController : MonoBehaviour
    {

        public TMP_Text scoreText;
        public TMP_Text highscoreText;

        // Start is called before the first frame update
        void Start()
        {
            scoreText.text = "Score: " + ScoreManager.GetScore().ToString();
            highscoreText.text = "Highscore: " + ScoreManager.GetHighscore().ToString();
        }

    }
}