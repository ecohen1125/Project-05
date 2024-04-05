using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera mazeOverview;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = true;
        mazeOverview.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Time.timeScale == 0f)
                Time.timeScale = 1.0f;
            else
                Time.timeScale = 0f;
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            mazeOverview.enabled = !mazeOverview.enabled;
            text.SetActive(!text.activeSelf);
        }
    }
}
