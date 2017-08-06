using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Bikin array Question Class dengan nama question
    public Question[] questions;
    //bikin list Class Question yang belum ditampilin
    private static List<Question> unansweredQuestions;
    
    private static int questionCount = 5;
    private static bool scoreAdd = false;
    public static int score = 0;

    private Question currentQuestion;

    //[SerializeField] >> untuk memaksa Unity menampilkan hal dengan akses type private pada inspector
    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestion;

    [SerializeField]
    private Text trueText;

    [SerializeField]
    private Text falseText;

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        questionCount -= 1;
        if ((questionCount+1) == 0)
        {
            Application.LoadLevel("Score");
        }

        if (scoreAdd)
        {
            score += 1;
            
            Debug.Log("score: "+score);
        }
        
        Debug.Log("question count: "+questionCount);
        

        scoreAdd = false;
    }

    private void Start()
    {
        //ketika game baru dimulai, unansweredQuestion akan == null, maka diisi oleh array questions yang dikonversi menjadi List
        //ketika semua pertanyaan ditampilkan, maka unansweredQuestion.Count akan == 0
        //(karena pada script ini kita pake unansweredQuestion.remove setiap kali pertanyaan dijawab)
        //List pertanyaan direset setiap kali semua pertanyaan terjawab

        

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        GetRandomQuestion();
        
    }

    private void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueText.text = "CORRECT!";
            falseText.text = "WRONG!";
        } else
        {
            trueText.text = "WRONG!";
            falseText.text = "CORRECT!";
        }

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void userChoiceTrue()
    {
        animator.SetTrigger("True");

        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            scoreAdd = true;
        }
        else Debug.Log("Wrong!");

        StartCoroutine(TransitionToNextQuestion());
    }
    public void userChoiceFalse()
    {
        animator.SetTrigger("False");

        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            scoreAdd = true;
        }
        else Debug.Log("Wrong!");

        StartCoroutine(TransitionToNextQuestion());
    }

}
