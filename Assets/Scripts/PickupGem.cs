using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGem : MonoBehaviour
{
    public int pointValue; 

    // Start is called before the first frame update
    void Start()
    {
        string temp = this.name;
        string[] tempSplit = temp.Split("(Clone)");

        pointValue = (int)GemSpawner.gemMap[tempSplit[0]];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        GameObject col = other.gameObject;
        if (col.tag == "Player") {
            GameController.points += pointValue;
            Destroy(this.gameObject);
        }
    }
}
