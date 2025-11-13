using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question : MonoBehaviour
{
    [Header("Questions")]
    public TextMeshProUGUI[] questions;

    [Header("References")]
    public Transform spawnparent;
    public TriviaGame triviagame;



    private void OnEnable()
    {
        PickRandomQuestion();
    }
    public TextMeshProUGUI PickRandomQuestion()
    {
        if (questions == null || questions.Length == 0)
        {
            Debug.LogWarning("No questions assigned!");
            return null;
        }

        int randomIndex = Random.Range(0, questions.Length);
        QuestionPicked(randomIndex);
        return questions[randomIndex];

    }

    public void QuestionPicked(int question)
    {
        TextMeshProUGUI newQuestion = Instantiate(questions[question], spawnparent);
        triviagame.QuestionChosen(question);
    }
}
