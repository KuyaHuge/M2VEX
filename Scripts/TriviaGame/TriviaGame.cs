using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TriviaGame : MonoBehaviour
{
    [Header("Answers of Questions")]
    public GameObject[] answers;

    [Header("References")]
    public Transform spawnparent;
    PadlockStatus padlockstatus;


    private void Start()
    {
        padlockstatus = GameObject.FindGameObjectWithTag("PadlockHolder").GetComponent<PadlockStatus>();
        
    }

    public void QuestionChosen(int question)
    {
        // Spawn prefab
        GameObject newAnswer = Instantiate(answers[question], spawnparent);

        // Get Answer script and give it a reference to this TriviaGame
        Answer answerScript = newAnswer.GetComponent<Answer>();
        if (answerScript != null)
        {
            answerScript.Initialize(this);
        }
    }

    public void CorrectAnswer()
    {
        Debug.Log("Correct!");
        Destroy(gameObject); // Destroys TriviaGame's GameObject
        GlobalManager.instance.Padlock(padlockstatus.name, false);
        SatisfactoryBar.instance.AddSatisfaction(25);
        EventLogs.instance.IncreaseSatisfaction(25);
        GameManager.Instance.CheckGames();
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong!");
        Destroy(gameObject); // Destroys TriviaGame's GameObject
        GlobalManager.instance.Padlock(padlockstatus.name, false);
        SatisfactoryBar.instance.TakeSatisfaction(25);
        EventLogs.instance.DecreaseSatisfaction(25);
        GameManager.Instance.CheckGames();
    }
}
