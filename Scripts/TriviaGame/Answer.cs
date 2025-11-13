using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Answer : MonoBehaviour, IPointerClickHandler
{

    [Header("References")]
    TriviaGame triviaGame;   // Assigned at runtime

    [Header("Answer Settings")]
    public bool isCorrect; // Set in Inspector for each answer prefab

    void Awake()
    {
        triviaGame = GameObject.FindGameObjectWithTag("TriviaGame").GetComponent<TriviaGame>();
    }

    // Called by TriviaGame right after instantiation
    public void Initialize(TriviaGame game)
    {
        triviaGame = game;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (triviaGame == null)
        {
            Debug.LogWarning("TriviaGame reference missing!");
            return;
        }

        if (isCorrect)
            triviaGame.CorrectAnswer();
        else
            triviaGame.WrongAnswer();


    }
}
