using UnityEngine;

public static class ScoreManager
{
    private static int _score = 0;
    private static int _highscore = 0;
    private static int _eggCounter = 0;


    public static void AddScore(bool isBomb)
    {
        if (isBomb)
        {
            TimeManager.AddTime(-10);
            return;
        }
        else
        {
            _eggCounter++;
        }
        if (_eggCounter >= 20)
        {
            TimeManager.AddTime(10);
            _eggCounter = 0;
        }
        _score += 10;
        if (_score >= _highscore)
        {
            _highscore = _score;
        }
    }

    public static int GetScore() { return _score; }
    public static int GetHighscore() { return _highscore; }

    public static void Reset() { 
        _score = 0;
        SaveData data = SaveSystem.LoadHighscore();
        if (data != null)
            _highscore = data.highscore;
    }

}
