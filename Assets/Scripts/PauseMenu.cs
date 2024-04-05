using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;

    public GameObject timeText;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Pause();
                scoreText.SetActive(false);
                timeText.SetActive(false);
            }

            if (!isPaused) 
            { 
                Unpause();
                scoreText.SetActive(true);
                timeText.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
