using UnityEngine;

public static class TimeManager
{
    private static int _timer = 60;
    private static float _elapsedTime = 0.0f;


    public static void UpdateTimer()
    {
        if (_timer <= 0)
        {
            _timer = 0;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 1.0f)
            {
                _elapsedTime = 0.0f;
                _timer--;
            }
        }
    }

    public static int GetTimer() { return _timer; }
    public static void AddTime(int t)
    {
        _timer += t;
    }

    public static void Reset()
    {
        _timer = 60;
        _elapsedTime = 0.0f;
    }
}
