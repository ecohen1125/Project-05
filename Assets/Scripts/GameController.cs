using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public TMP_Text score;
    public static int points = 0;
    public TMP_Text time;
    float timePassed = 0;
    float timePassedInt;
    public int minutes;
    public int seconds;
    public int testPoints;
    Scene scene;

    void Awake() {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        minutes = 3;
        seconds = 0;

        points += testPoints;
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Maze") {
            timePassed += Time.deltaTime;
            timePassedInt = Mathf.FloorToInt(timePassed);
            if (timePassedInt >= 1) {
                if (minutes == 0 && seconds == 0) {
                    SceneManager.LoadScene("EndScene");
                } else if (seconds == 0) {
                    seconds = 59;
                    minutes--;
                } else {
                    seconds--;
                }

                timePassedInt = 0;
                timePassed = 0;
            }



            time.text = "Time: " + minutes + ":" + seconds.ToString().PadLeft(2, '0');

            score.text = "Score: " + points.ToString();
        }
    }
}