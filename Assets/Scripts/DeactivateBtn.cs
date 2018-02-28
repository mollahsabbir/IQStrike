using UnityEngine;
using System.Collections;


public class DeactivateBtn : MonoBehaviour
{

    public GameObject startButton;         //I have selected the Button in Inspector
    public bool isTrue = false;             

    [SerializeField]
    private float timeForBtn = 1f;

    public IEnumerator showBtn()
    {
        yield return new WaitForSeconds(timeForBtn);
        isTrue = true;
        
        

    }

    
    void Update()
    {
        StartCoroutine(showBtn());
        startButton.SetActive(isTrue);
    }

    
    void btnStatus()
    {
       startButton.SetActive(false);
    }

}