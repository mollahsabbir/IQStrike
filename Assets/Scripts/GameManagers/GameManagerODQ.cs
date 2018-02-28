using UnityEngine;
using System.Collections;
using System.Collections.Generic;           
using System.Linq;              
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerODQ : MonoBehaviour {

    public ODQqstn[] odqqstns;
    private static List<ODQqstn> unansweredODQ;

    public static int _x = 0;

    private ODQqstn currentODQquestion;


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
        if (unansweredODQ == null || unansweredODQ.Count == 0)
        {
            unansweredODQ = odqqstns.ToList<ODQqstn>();

        }

        SetCurrentQuestion();

        SetCurrentChoice1();
        SetCurrentChoice2();
        SetCurrentChoice3();
        SetCurrentChoice4();

    }

    void SetCurrentQuestion()
    {
        int randomODQIndex = Random.Range(0, unansweredODQ.Count);
        currentODQquestion = unansweredODQ[randomODQIndex];

        questionText.text = currentODQquestion.odqQuestion;

        unansweredODQ.RemoveAt(randomODQIndex);
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredODQ.Remove(currentODQquestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        _x += 1;                                                                              //To calculate the question number and change Game Scene after 5 questions
        if (_x < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("GameSceneLDQ");
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


        int y = currentODQquestion.rightODQAnswer;
        Debug.Log(y);
        
        if (currentODQquestion.rightODQAnswer == x - 1)
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
                    textWrongAnswer.text = "Correct Answer is " + currentODQquestion.odqChoice1;
                    break;
                case 1:
                    textWrongAnswer.text = "Correct Answer is " + currentODQquestion.odqChoice2;
                    break;
                case 2:
                    textWrongAnswer.text = "Correct Answer is " + currentODQquestion.odqChoice3;
                    break;
                case 4:
                    textWrongAnswer.text = "Correct Answer is " + currentODQquestion.odqChoice4;
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
        Choice1.text = currentODQquestion.odqChoice1;
    }
        void SetCurrentChoice2()
    {
        Choice2.text = currentODQquestion.odqChoice2;
    }
        void SetCurrentChoice3()
    {
        Choice3.text = currentODQquestion.odqChoice3;
    }
        void SetCurrentChoice4()
    {
        Choice4.text = currentODQquestion.odqChoice4;
    }
}
