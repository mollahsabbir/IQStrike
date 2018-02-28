using UnityEngine;
using System.Collections;
using System.Collections.Generic;           
using System.Linq;              
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerGKQ : MonoBehaviour {

    public GKQqstn[] gkqqstns;
    private static List<GKQqstn> unansweredGKQ;

    public static int _x = 0;                                              //Created to change Game Scene after _x count gets to 5.
    public int _y;                                               // For Score management



    public AudioSource rightAnswer;
    public AudioClip rightAnswerClip;
    public AudioSource wrongAnswer;
    public AudioClip wrongAnswerClip;

    GameObject Choice1disable;
    GameObject Choice2disable;
     GameObject Choice3disable;
    GameObject Choice4disable;

    private GKQqstn currentGKQquestion;

    [SerializeField]
    private Text textCorrectAnswer;
    [SerializeField]
    private Text textWrongAnswer;
    [SerializeField]
    private Text textWrongAnswer2;


    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text Choice1;

    [SerializeField]
    private Text Choice2;

    [SerializeField]
    private Text Choice3;

    [SerializeField]
    private Text Choice4;


    [SerializeField]
    private float timeBetweenQuestions = 1f;


                                                          

    

    void Start()
    {
                                                                       
        
        

        if (unansweredGKQ == null || unansweredGKQ.Count == 0)
        {
            unansweredGKQ = gkqqstns.ToList<GKQqstn>();

        }

        SetCurrentQuestion();

        SetCurrentChoice1();
        SetCurrentChoice2();
        SetCurrentChoice3();
        SetCurrentChoice4();

       
       

    }

    void SetCurrentQuestion()
    {
        int randomGKQIndex = Random.Range(0, unansweredGKQ.Count);
        currentGKQquestion = unansweredGKQ[randomGKQIndex];

        questionText.text = currentGKQquestion.gkqQuestion;

        unansweredGKQ.RemoveAt(randomGKQIndex);
        
    }

    IEnumerator TransitionToNextQuestion ()                                
    {
        unansweredGKQ.Remove(currentGKQquestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        _x += 1;                                                                              //To calculate the question number and change Game Scene after 5 questions
        if ( _x < 5 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("GameSceneTFQ");
            _x = 0;
        }
        Debug.Log("_x" +_x);
        
        
    }

    public void UserSelect(int x)
    {

        Choice1disable = GameObject.Find("Choice1");
        Choice1disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice2disable = GameObject.Find("Choice2");
        Choice2disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice3disable = GameObject.Find("Choice3");
        Choice3disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice4disable = GameObject.Find("Choice4");
        Choice4disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        int y = currentGKQquestion.rightGKQAnswer;
            Debug.Log("User Selected " + y);

            if (currentGKQquestion.rightGKQAnswer == x - 1)
            {

                textCorrectAnswer.text = "CORRECT";

                ScoreSet();


                Debug.Log("Score: " + PlayerPrefs.GetInt("ScorePrefs"));

            rightAnswer.PlayOneShot(rightAnswerClip);

            }


            else

            {

                textWrongAnswer2.text = "WRONG";

                switch (y)
                {
                    case 0:
                        textWrongAnswer.text = "Correct Answer is " + currentGKQquestion.gkqChoice1;
                        break;
                    case 1:
                        textWrongAnswer.text = "Correct Answer is " + currentGKQquestion.gkqChoice2;
                        break;
                    case 2:
                        textWrongAnswer.text = "Correct Answer is " + currentGKQquestion.gkqChoice3;
                        break;
                    case 3:
                        textWrongAnswer.text = "Correct Answer is " + currentGKQquestion.gkqChoice4;
                        break;
                }
            wrongAnswer.PlayOneShot(wrongAnswerClip);

                Debug.Log("Wrong");
            }

            StartCoroutine(TransitionToNextQuestion());
        
    }


   

    public void ScoreSet()
    {

        _y = PlayerPrefs.GetInt("ScorePrefs");
        PlayerPrefs.SetInt("ScorePrefs", _y + 1);

    }

  



        void SetCurrentChoice1()
    {
        Choice1.text = currentGKQquestion.gkqChoice1;
    }
        void SetCurrentChoice2()
    {
        Choice2.text = currentGKQquestion.gkqChoice2;
    }
        void SetCurrentChoice3()
    {
        Choice3.text = currentGKQquestion.gkqChoice3;
    }
        void SetCurrentChoice4()
    {
        Choice4.text = currentGKQquestion.gkqChoice4;
    }
}
