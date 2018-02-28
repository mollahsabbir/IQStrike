using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    void Start()
    {
        ExitPopUp.SetActive(false);
    }

    public GameObject ExitPopUp;

    public void ChangeToScene(string sceneToChangeTo)
      {
        SceneManager.LoadScene(sceneToChangeTo);      
      }

    public void OpenPopUP()
    {
        ExitPopUp.SetActive(true);
    }

    public void ClosePopUP()
    {
        ExitPopUp.SetActive(false);
    }


    public void ExitIQBtn()
        {
            Application.Quit();
        }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

}