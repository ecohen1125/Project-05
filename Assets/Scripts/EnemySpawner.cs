using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    RaycastHit hit;
    public NavMeshSurface[] surfaces;
    public NavMeshSurface path;
    public float spawnTime;
    float spawnTimer;

    public GameObject ceiling;

    // Start is called before the first frame update
    void Start()
    {
        ceiling.SetActive(false);
        surfaces = GameObject.FindObjectsOfType<NavMeshSurface>();

        surfaces[0].BuildNavMesh();
        
        for (int i = 1;  i < surfaces.Length; i++)
        {
            Destroy(surfaces[i]);
        }

        ceiling.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
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

    public void BuildNavMesh() {
        foreach (var surface in surfaces) {
            surface.BuildNavMesh();
        }
    }
}
