using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager2 : MonoBehaviour {

    [SerializeField]
    private Text Scorew;


    [SerializeField]
    private Text ScoreStatus;

    void Start()
    {
        int _score = PlayerPrefs.GetInt("ScorePrefs");
        int _highscore = PlayerPrefs.GetInt("HighScorePrefs");

        if (_score > _highscore)
        {
            PlayerPrefs.SetInt("HighScorePrefs", _score);
        }
        WriteScoreStatus();
        WriteScore();
    }


    void WriteScore()
    {
        int y = (PlayerPrefs.GetInt("ScorePrefs"));
        int z = y * 5;
        string x = z.ToString();
        Scorew.text = ( x );
    }


    void WriteScoreStatus()
    {
        int g = (PlayerPrefs.GetInt("ScorePrefs"));
        int h = g * 5;

        if (h == 200)
        {
            ScoreStatus.text = ("You are a GENIUS!!!");
        }

        else if (h >= 160)
        {
            ScoreStatus.text = ("You are Highly Bright!!!");
        }

        else if (h >= 120)
        {
            ScoreStatus.text = ("You are Bright");
        }

        else if (h >= 80)
        {
            ScoreStatus.text = ("Your score is average. Try more!");
        }

        else if (h >= 40)
        {
            ScoreStatus.text = ("Are you even trying?");
        }

        else
        {
            ScoreStatus.text = ("You might want to check out the Learn section first.");
        }

    }
}

