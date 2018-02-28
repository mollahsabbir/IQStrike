using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderManage : MonoBehaviour {

    public Slider slider1;
    public Slider slider2;

    // Use this for initialization
    public void SayMusic()
    {
        float _musicVolume2 = slider1.value;
        PlayerPrefs.SetFloat("MusicVolumePrefs", _musicVolume2);
        Debug.Log(PlayerPrefs.GetFloat("MusicVolumePrefs")); 
    }

    public void SaySound()
    {
        float _soundVolume2 = slider2.value;
        PlayerPrefs.SetFloat("SoundVolumePrefs", _soundVolume2);
    }

    void Start()                    //set Slider Value
    {

        float _musicValue = PlayerPrefs.GetFloat("MusicVolumePrefs");
        slider1.value = _musicValue;

        float _soundVolume = PlayerPrefs.GetFloat("SoundVolumePrefs");
        slider2.value = _soundVolume;

       
    }

  

  
}
