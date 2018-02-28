using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RightAnswerSound : MonoBehaviour
{

    public GameObject rightAnswerSound;
    void Awake()
    {
        rightAnswerSound = GameObject.FindGameObjectWithTag("RightAnswer");

    }


    void Start()
    {
        rightAnswerSound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundVolumePrefs");
    }

    // Update is called once per frame
    void Update()
    {

    }
}