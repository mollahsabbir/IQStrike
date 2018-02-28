using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text HighScorew;

    // Use this for initialization
    void Start()
    {
         if (!(PlayerPrefs.HasKey("HighScorePrefs")))
         {
             PlayerPrefs.SetInt("HighScorePrefs", 0);
         }
        
        SetHighScore();
    }



        public void SetHighScore()
    {


        int y = PlayerPrefs.GetInt("HighScorePrefs");
        
        Debug.Log(y);
        if ( y == 0 )
        {
            HighScorew.text = ("---");
        }
        else if ( y != 0 )
        {
            HighScorew.text = (y*5).ToString();
        }
    }

    public void ScoreResetButton()                                                 //Score Sets to 0 on "IQ STRIKE" Button Press
    {
        PlayerPrefs.SetInt("ScorePrefs", 0);
    }

}
