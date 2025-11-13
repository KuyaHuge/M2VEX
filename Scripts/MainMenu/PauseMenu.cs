using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;   // Global pause state
    [Header("UI")]
    [SerializeField] private GameObject pauseMenuUI; // Assign your pause menu panel here in Inspector

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        // Toggle pause with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;   // Resume game time
        isPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;   // Stop game time
        isPaused = true;
    }

    // Optional: hook this to a Quit button
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
