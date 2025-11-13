using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public GameObject[] Games;
    public GameObject Choosegame;
    public GameObject Finished;
    public GameObject FinalMessage;

    public Transform spawnparent;

    [Header("Final Quiz")]
    public GameObject finalquiz;

    public int GameCount;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckGames()
    {
        GameCount++;
        if (GameCount == 10)
        {
            Instantiate(Finished, spawnparent);
        }
    }

    public void PlayTrivia()
    {
        Instantiate(Games[0], spawnparent);
        Choosegame.SetActive(false);
    }

    public void PlayRhythm()
    {
        Instantiate(Games[1], spawnparent);
        Choosegame.SetActive(false);
    }

    public void Next()
    {
        Destroy(finalquiz);
        Instantiate(FinalMessage, spawnparent);
        StartCoroutine(EndofManager());
    }
    public void PlayMemory()
    {
        Instantiate(Games[2], spawnparent);
        Choosegame.SetActive(false);
    }

    public void ActiveChooseGame()
    {
        Choosegame.SetActive(true);
    }

    IEnumerator EndofManager()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
