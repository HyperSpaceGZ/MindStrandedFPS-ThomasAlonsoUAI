using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform Target;
    public Animator animator;
    void Start()
    {

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

    }


    private void SetDestination()
    {
        agent.destination = Target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.destination = other.gameObject.transform.position;
            InvokeRepeating(nameof(SetDestination), 0f, 1f);
            animator.Play("Armature|Walk_Cycle_1");
        }
    }

}
