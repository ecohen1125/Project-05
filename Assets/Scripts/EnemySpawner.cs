using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    RaycastHit hit;
    public NavMeshSurface[] surface;
    //public NavMeshSurface path;
    public float spawnTime;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        surface = GameObject.FindObjectsOfType<NavMeshSurface>();

        for (int i = 1;  i < surface.Length; i++)
        {
            Destroy(surface[i]);
        }

        /*for (int i = 0; i < surface.Length; i++) {
            surface[i].BuildNavMesh();
        }*/

        surface[0].BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0) {
            int randomX = Random.Range(5, 37);
            int randomZ = Random.Range(5, 37);

            randomX = randomX - (randomX % 4);
            randomZ = randomZ - (randomZ % 4);

            int randomSpawn = Random.Range(0, enemies.Length);
            Vector3 spawnPos = new Vector3(randomX, 0, randomZ);

            Instantiate(enemies[randomSpawn], spawnPos, Quaternion.identity, this.gameObject.transform);

            spawnTimer = spawnTime;
        } else {
            spawnTimer -= Time.deltaTime;
        }
    }
}
