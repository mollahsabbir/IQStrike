using UnityEngine;
using System.Collections;

public class StartKeyPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!(PlayerPrefs.HasKey("MusicVolumePrefs"))) 
        {
            PlayerPrefs.SetFloat("MusicVolumePrefs", 0.5f);
        }
        if(!(PlayerPrefs.HasKey("SoundVolumePrefs"))) 
        {
            PlayerPrefs.SetFloat("SoundVolumePrefs", 0.5f);
        }
    }
	

    public void SetGameStartTime()
    {
        float y = Time.time;
        PlayerPrefs.SetFloat("GameStartTime", y);
    }
}
