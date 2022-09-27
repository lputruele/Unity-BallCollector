using TMPro;
using UnityEngine;


namespace Game.UI
{
    /// <summary>
    /// A MonoBehaviour for controlling the UI of the game scene.
    /// </summary>
    public class InGameUIController : MonoBehaviour
    {

        public TMP_Text scoreText;
        public TMP_Text highscoreText;
        public TMP_Text timerText;

        // Start is called before the first frame update
        void Start()
        {
            scoreText.text = "Score: " + ScoreManager.GetScore().ToString();
            highscoreText.text = "Highscore: " + ScoreManager.GetHighscore().ToString();
            timerText.text = "Timer: " + TimeManager.GetTimer().ToString();
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + ScoreManager.GetScore().ToString();
            highscoreText.text = "Highscore: " + ScoreManager.GetHighscore().ToString();
            timerText.text = "Timer: " + TimeManager.GetTimer().ToString();
        }
    }
}