using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEditor.AI;
using Unity.AI.Navigation;

public class Enemy : MonoBehaviour {

    float newDestinationTime;
    float tempDestinationTime;
    public float speed;

    public Animator anim;
    NavMeshAgent agent;
    public AudioSource minotaurSound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        newDestinationTime = Random.Range(0, 5);
        agent.speed = speed;

        minotaurSound = GameObject.FindGameObjectWithTag("minotaurSound").GetComponent<AudioSource>();
    }

    void Update () 
	{
        if (tempDestinationTime <= 0)
        {
            if (!(agent.hasPath || agent.remainingDistance > 0.1))
            {
                Vector3 movePos = new Vector3(Random.Range(0, 36), 0, Random.Range(0, 36));
                Vector3 destination = (Random.insideUnitSphere * 3) + transform.position;
                agent.SetDestination(movePos);
            }
            tempDestinationTime = newDestinationTime;
        } 
        else
        {
            tempDestinationTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("heart");
            minotaurSound.Play(0);

            GameController.health--;
            Destroy(hearts[0]);
        }
    }
}

