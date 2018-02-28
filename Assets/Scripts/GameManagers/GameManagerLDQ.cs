using UnityEngine;
using System.Collections;
using System.Collections.Generic;           
using System.Linq;              
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLDQ : MonoBehaviour {

    public LDQqstn[] ldqqstns;                                                      //USed this script as Letter Difference. CLQ=LDQ
    private static List<LDQqstn> unansweredLDQ;

    public static int _x;

  

    private LDQqstn currentLDQquestion;

    public GameObject Choice1disable;
    public GameObject Choice2disable;
    public GameObject Choice3disable;
    public GameObject Choice4disable;


    public AudioSource rightAnswer;
    public AudioClip rightAnswerClip;
    public AudioSource wrongAnswer;
    public AudioClip wrongAnswerClip;

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
        if (unansweredLDQ == null || unansweredLDQ.Count == 0)
        {
            unansweredLDQ = ldqqstns.ToList<LDQqstn>();

        }

        SetCurrentQuestion();

        SetCurrentChoice1();
        SetCurrentChoice2();
        SetCurrentChoice3();
        SetCurrentChoice4();

    }

    void SetCurrentQuestion()
    {
        int randomLDQIndex = Random.Range(0, unansweredLDQ.Count);
        currentLDQquestion = unansweredLDQ[randomLDQIndex];

        questionText.text = currentLDQquestion.ldqqstion;

        unansweredLDQ.RemoveAt(randomLDQIndex);
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredLDQ.Remove(currentLDQquestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        _x += 1;                                                                              //To calculate the question number and change Game Scene after 5 questions
        if (_x < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("GameSceneGMQ");
            _x = 0;
        }
        Debug.Log("_x" + _x);
    }

    public void UserSelect (int x)
    {


        Choice1disable = GameObject.Find("Choice1");
        Choice1disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice2disable = GameObject.Find("Choice2");
        Choice2disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice3disable = GameObject.Find("Choice3");
        Choice3disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        Choice4disable = GameObject.Find("Choice4");
        Choice4disable.GetComponent<UnityEngine.UI.Button>().enabled = false;

        int y = currentLDQquestion.rightLDQAnswer;
        Debug.Log(y);
        
        if (currentLDQquestion.rightLDQAnswer == x - 1)
        {

            textCorrectAnswer.text = "CORRECT!";

            Debug.Log("Correct");

            ScoreSet();


            Debug.Log("Score: " + PlayerPrefs.GetInt("ScorePrefs"));
            rightAnswer.PlayOneShot(rightAnswerClip);

        }

        else

        {

            textWrongAnswer2.text = "WRONG!";

            switch (y)
            {
                case 0:
                    textWrongAnswer.text = "Correct Answer is " + currentLDQquestion.ldqChoice1;
                    break;
                case 1:
                    textWrongAnswer.text = "Correct Answer is " + currentLDQquestion.ldqChoice2;
                    break;
                case 2:
                    textWrongAnswer.text = "Correct Answer is " + currentLDQquestion.ldqChoice3;
                    break;
                case 4:
                    textWrongAnswer.text = "Correct Answer is " + currentLDQquestion.ldqChoice4;
                    break;
            }

            wrongAnswer.PlayOneShot(wrongAnswerClip);
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }



    public int _y;

    public void ScoreSet()
    {

        _y = PlayerPrefs.GetInt("ScorePrefs");
        PlayerPrefs.SetInt("ScorePrefs", _y + 1);

        

    }


    void SetCurrentChoice1()
    {
        Choice1.text = currentLDQquestion.ldqChoice1;
    }
        void SetCurrentChoice2()
    {
        Choice2.text = currentLDQquestion.ldqChoice2;
    }
        void SetCurrentChoice3()
    {
        Choice3.text = currentLDQquestion.ldqChoice3;
    }
        void SetCurrentChoice4()
    {
        Choice4.text = currentLDQquestion.ldqChoice4;
    }
}
