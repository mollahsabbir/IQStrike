using UnityEngine;
using System.Collections;

public class StartMusicVolume : MonoBehaviour {

    public GameObject startSceneVolume;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        startSceneVolume.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolumePrefs");
    }
}
