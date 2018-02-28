using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMusicControl : MonoBehaviour {

    public GameObject[] gameMusicObj;
    public GameObject gameMusic;
   


    void Awake()
    {
        gameMusicObj = GameObject.FindGameObjectsWithTag("music2");
        if (gameMusicObj.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        
        

    }

    void Update()
    {
        int levelnum = SceneManager.GetActiveScene().buildIndex;

        if (levelnum == 21 || levelnum == 1)
            Destroy(this.gameObject);
       
    }

    void Start()
    {
         

        gameMusic.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolumePrefs");
    }

}
