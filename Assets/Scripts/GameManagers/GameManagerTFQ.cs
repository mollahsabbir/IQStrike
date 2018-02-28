using UnityEngine;
using System.Collections;
using System.Collections.Generic;           
using System.Linq;              
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerTFQ : MonoBehaviour {

    public TFQqstn[] tfqqstns;
    private static List<TFQqstn> unansweredTFQ;

    public static int _x = 0;

    private TFQqstn currentTFQquestion;


    public GameObject Choice1disable;
    public GameObject Choice2disable;

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
    private float timeBetweenQuestions = 1f;

    void Start()
    {
        if (unansweredTFQ == null || unansweredTFQ.Count == 0)
        {
            unansweredTFQ = tfqqstns.ToList<TFQqstn>();

        }

        SetCurrentQuestion();

        SetCurrentChoice1();
        SetCurrentChoice2();
        

    }

    void SetCurrentQuestion()
    {
        int randomTFQIndex = Random.Range(0, unansweredTFQ.Count);
        currentTFQquestion = unansweredTFQ[randomTFQIndex];

        questionText.text = currentTFQquestion.tfqQuestion;

        unansweredTFQ.RemoveAt(randomTFQIndex);
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredTFQ.Remove(currentTFQquestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        _x += 1;                                                                              //To calculate the question number and change Game Scene after 5 questions
        if (_x < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("GameSceneODQ");
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


        int y = currentTFQquestion.rightTFQAnswer;
        Debug.Log(y);
        
        if (currentTFQquestion.rightTFQAnswer == x - 1)
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
                    textWrongAnswer.text = "Correct Answer is " + currentTFQquestion.tfqChoice1;
                    break;
                case 1:
                    textWrongAnswer.text = "Correct Answer is " + currentTFQquestion.tfqChoice2;
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
        Choice1.text = currentTFQquestion.tfqChoice1;
    }
        void SetCurrentChoice2()
    {
        Choice2.text = currentTFQquestion.tfqChoice2;
    }
     
}
