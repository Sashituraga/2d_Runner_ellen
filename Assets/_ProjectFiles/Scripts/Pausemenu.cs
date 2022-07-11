using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausemenu : MonoBehaviour
{
    public static Pausemenu instance;
    public bool GameIsPaused;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        Debug.Log("::::: " + GameIsPaused);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1F;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0F;
        GameIsPaused = true;

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

