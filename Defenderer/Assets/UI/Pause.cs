using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseScreen;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TriggerEscape();
           
    }

    public void TriggerEscape()
    {
        if (paused)
        {
            pauseScreen.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
