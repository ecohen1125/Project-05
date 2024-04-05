using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject[] gems;
    public string[] names;
    public static Dictionary<string, float> gemMap;
    float value = 2;
    public float spawnTimer;
    float time;

    // Start is called before the first frame update
    void Start() {
        gemMap = new Dictionary<string, float>();

        for (int i = 0; i < gems.Length; i++) {
            string thing = gems[i].name;
            gemMap[thing] = Mathf.Pow(value, (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0) {
            /* 50% -> gem[0]
             * 30% -> gem[1]
             * 10% -> gem[2]
             * 7%  -> gem[3]
             * 3%  -> gem[4]
             */

            float spawnNum = Random.Range(0f, 1f);

            switch (spawnNum) {
                case float n when (n >= 0) && (n < 0.5):
                spawnGem(gems[0]);
                    break;
                case float n when (n >= 0.5) && (n < 0.8):
                    spawnGem(gems[1]); 
                    break;
                case float n when (n >= 0.8) && (n < 0.9):
                    spawnGem(gems[2]);
                    break;
                case float n when (n >= 9) && (n < 0.97):
                    spawnGem(gems[3]); 
                    break;
                case float n when (n >= 0.97) && (n < 1):
                    spawnGem(gems[4]); 
                    break;
                default:
                    break;
            }

            time = spawnTimer;
        } else {
            time -= Time.deltaTime;
        }
    }

    void spawnGem(GameObject gem) {
        //GameObject parent = GameObject.Find("Gems").gameObject;
        int spawnX = Random.Range(4, 37);
        int spawnZ = Random.Range(4, 37);

        spawnX = spawnX - (spawnX % 4);
        spawnZ = spawnZ - (spawnZ % 4);

        Vector3 spawnPos = new Vector3(spawnX, 0.75f, spawnZ);

        Instantiate(gem, spawnPos, Quaternion.Euler(new Vector3(270, 0, 0)), this.gameObject.transform);
    }
}
