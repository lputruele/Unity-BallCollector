using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highscore;

    public SaveData(int score)
    {
        highscore = score;
    }
}
