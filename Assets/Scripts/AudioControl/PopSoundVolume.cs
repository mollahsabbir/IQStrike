using UnityEngine;
using System.Collections;

public class PopSoundVolume : MonoBehaviour {

    public GameObject popSound;
    void Awake()
    {
        popSound = GameObject.FindGameObjectWithTag("PopSound");

    }


    void Start()
    {
        popSound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundVolumePrefs");
    }
}
