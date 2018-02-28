using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WrongAnswerSound : MonoBehaviour
{

    public GameObject wrongAnswerSound;
    void Awake()
    {
        wrongAnswerSound = GameObject.FindGameObjectWithTag("WrongAnswer");
        
    }


    void Start()
    {
        wrongAnswerSound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundVolumePrefs");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
