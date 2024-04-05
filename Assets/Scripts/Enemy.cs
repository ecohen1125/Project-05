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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        newDestinationTime = Random.Range(0, 5);
        agent.speed = speed;
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

        //anim.SetBool("RUN", false);
        //anim.SetBool("Attack", true);
    }
}

