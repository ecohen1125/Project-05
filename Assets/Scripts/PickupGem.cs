using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PickupGem : MonoBehaviour
{
    public int pointValue;
    public AudioSource clip;

    public GameObject gemSoundObject;

    // Start is called before the first frame update
    void Start()
    {
        string temp = this.name;
        string[] tempSplit = temp.Split("(Clone)");

        pointValue = (int)GemSpawner.gemMap[tempSplit[0]];

        gemSoundObject = GameObject.FindGameObjectWithTag("gemSound");
        clip = gemSoundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        GameObject col = other.gameObject;
        if (col.tag == "Player") {
            GameController.points += pointValue;
            clip.Play(0);
            StartCoroutine(waitForSound());
        }
    }

    IEnumerator waitForSound() {
        //Wait Until Sound has finished playing
        while (clip.isPlaying) {
            yield return null;
        }

        //Auidio has finished playing, disable GameObject
        Destroy(this.gameObject);
    }
}
