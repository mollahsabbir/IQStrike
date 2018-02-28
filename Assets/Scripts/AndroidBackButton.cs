using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AndroidBackButton : MonoBehaviour
{

   

    public GameObject AndroidExitPopUp;

    void Start()
    {
       
    }


    public string KnowLevelName;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (KnowLevelName)
            {
                case "StartScene":
                    AndroidExitPopUp.SetActive(true);
                    break;
                case "GameSceneGKQ":
                    AndroidExitPopUp.SetActive(true);
                    break;
                
                case "SettingsScene":
                    SceneManager.LoadScene(1);
                    break;
                case "CreditsScene":
                    SceneManager.LoadScene(1);
                    break;
                case "LearnSceneGKQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneTFQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneGMQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneAMQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneALQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneODQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneLDQ":
                    SceneManager.LoadScene(3);
                    break;
                case "LearnSceneJWQ":
                    SceneManager.LoadScene(3);
                    break;

                case "LearnScene":
                    SceneManager.LoadScene(1);
                    break;

            }
        }
        
    }

    
             
            
        
        
}
