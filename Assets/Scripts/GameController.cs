using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public TMP_Text score;
    public static int points = 0;
    public TMP_Text time;
    float timePassed = 0;
    float timePassedInt;
    public int minutes;
    public int seconds;
    Scene scene;

    public GameObject heartsParent;
    public Sprite heart;
    public static int health;

    void Awake() {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        minutes = 3;
        seconds = 0;

        health = 3;

        for (int i = 0; i < health;  i++) {
            GameObject NewObj = new GameObject();
            Image NewImage = NewObj.AddComponent<Image>();
            NewImage.sprite = heart;
            NewObj.GetComponent<RectTransform>().SetParent(heartsParent.transform);
            NewObj.transform.localScale = Vector3.one;
            NewObj.transform.transform.localPosition = new Vector3((i * -125), 0, 0);
            NewObj.tag = "heart";
            NewObj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Maze") {
            timePassed += Time.deltaTime;
            timePassedInt = Mathf.FloorToInt(timePassed);
            if (timePassedInt >= 1) {
                if ((minutes == 0 && seconds == 0) || health == 0) {
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