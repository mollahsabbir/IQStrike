using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicKeeper : MonoBehaviour {

    public GameObject[] objs;
	

    void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1) 
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
	
    void Update()
    {
        int levelnum = SceneManager.GetActiveScene().buildIndex;

        if (levelnum == 2)
            Destroy(this.gameObject);
    }

}

