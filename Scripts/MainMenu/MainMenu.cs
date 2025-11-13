using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Quit;
    public GameObject start;


    private void Start()
    {
        Quit.SetActive(false);
        start.SetActive(false);
    }
    public void StartGame()
    {
        start.SetActive(true);
        StartCoroutine(message());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }
    IEnumerator message()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("FirstFloor");
    }
}
