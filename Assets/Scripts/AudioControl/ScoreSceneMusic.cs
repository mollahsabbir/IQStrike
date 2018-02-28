using UnityEngine;
using System.Collections;

public class ScoreSceneMusic : MonoBehaviour {


    public GameObject scoreSceneVolume;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        scoreSceneVolume.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolumePrefs");   //Intro Scene and Score Scene
    }
}
