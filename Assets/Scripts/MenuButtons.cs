using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "EndScene") {
            score.text = "Score: " + GameController.points.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {
        SceneManager.LoadScene("Maze");
    }

    public void Quit() {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Mainmenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
