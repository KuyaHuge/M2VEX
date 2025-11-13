using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalQuiz : MonoBehaviour
{
    public static FinalQuiz Instance;
    public int score;
    public int overall = 5;

    public Transform spawnParent;
    public Transform QuestionBG; 

    [Header("Questions")]
    public GameObject[] Questions;

    [Header("Answers")]
    public GameObject[] Answers;


    public GameObject results;
    private int questionindex;

    private GameObject currentQuestionUI;
    private GameObject currentAnswerUI;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        score = 0;
        questionindex = 0;
        CheckQuestion();
    }

    public void CorrectAnswer()
    {
        score++;
        questionindex++;  
        CheckQuestion();  
    }

    public void WrongAnswer()
    {
        questionindex++;
        CheckQuestion();
    }

    public void CheckQuestion()
    {
        if (currentQuestionUI != null) Destroy(currentQuestionUI);
        if (currentAnswerUI != null) Destroy(currentAnswerUI);

        if (questionindex < Questions.Length && questionindex < Answers.Length)
        {
            currentQuestionUI = Instantiate(Questions[questionindex].gameObject, QuestionBG);
            currentAnswerUI = Instantiate(Answers[questionindex], spawnParent);
        }
        else
        {
            Debug.Log("Quiz finished!");
            results.SetActive(true);
      
        }
    }
}
