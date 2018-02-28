using UnityEngine;
using System.Collections;
using System.Collections.Generic;           
using System.Linq;              
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerAMQ : MonoBehaviour {

    public AMQqstn[] amqqstns;
    private static List<AMQqstn> unansweredAMQ;

    public static int _x = 0; 

    private AMQqstn currentAMQquestion;



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
        if (unansweredAMQ == null || unansweredAMQ.Count == 0)
        {
            unansweredAMQ = amqqstns.ToList<AMQqstn>();

        }

        SetCurrentQuestion();

        SetCurrentChoice1();
        SetCurrentChoice2();
        SetCurrentChoice3();
        SetCurrentChoice4();

    }

    void SetCurrentQuestion()
    {
        int randomAMQIndex = Random.Range(0, unansweredAMQ.Count);
        currentAMQquestion = unansweredAMQ[randomAMQIndex];

        questionText.text = currentAMQquestion.amqQuestion;

        unansweredAMQ.RemoveAt(randomAMQIndex);
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredAMQ.Remove(currentAMQquestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        _x += 1;                                                                              //To calculate the question number and change Game Scene after 5 questions
        if (_x < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("GameSceneJWQ");
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

        int y = currentAMQquestion.rightAMQAnswer;
        Debug.Log(y);
        
        if (currentAMQquestion.rightAMQAnswer == x - 1)
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
                    textWrongAnswer.text = "Correct Answer is " + currentAMQquestion.amqChoice1;
                    break;
                case 1:
                    textWrongAnswer.text = "Correct Answer is " + currentAMQquestion.amqChoice2;
                    break;
                case 2:
                    textWrongAnswer.text = "Correct Answer is " + currentAMQquestion.amqChoice3;
                    break;
                case 4:
                    textWrongAnswer.text = "Correct Answer is " + currentAMQquestion.amqChoice4;
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
        Choice1.text = currentAMQquestion.amqChoice1;
    }
        void SetCurrentChoice2()
    {
        Choice2.text = currentAMQquestion.amqChoice2;
    }
        void SetCurrentChoice3()
    {
        Choice3.text = currentAMQquestion.amqChoice3;
    }
        void SetCurrentChoice4()
    {
        Choice4.text = currentAMQquestion.amqChoice4;
    }
}
