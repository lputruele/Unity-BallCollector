using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    private bool gameOver = false;
    private bool loadGameOverScene = false;
    public string gameOverSceneName;

    private void Start()
    {
        TimeManager.Reset();
        ScoreManager.Reset();
    }
    // Update timer
    void Update()
    {
        TimeManager.UpdateTimer();
        if (!gameOver && TimeManager.GetTimer() <= 0)
        {
            gameOver = true;
            loadGameOverScene  = true;
            SaveSystem.SaveHighscore(ScoreManager.GetHighscore());
        }
        if (loadGameOverScene)
        {
            AudioManager.instance.Play("GameOver");
            loadGameOverScene = false;
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

}