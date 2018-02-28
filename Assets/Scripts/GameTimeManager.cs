using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimeManager : MonoBehaviour {


    public float timeStart;
    public GameObject timeBar;

    // Use this for initialization
    void Start()
    {
        timeStart = PlayerPrefs.GetFloat("GameStartTime");
        timeBar = GameObject.Find("TimeProgress");
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - timeStart;
        timeBar.GetComponent<Image>().fillAmount = 1 - t / 300;

       
        if (t >= 300f)
        {
            SceneManager.LoadScene("ScoreScene");
        }
    }
}

