using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBoss : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform Target;
    public Animator animator;

    public GameObject MinionPrefab;
    public Transform MinionSpawner;

    public float MinionSpawnTimeMin = 10f;
    public float MinionSpawnTimeMax = 20f;
    void Start()
    {

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        MinionPrefab = GameObject.FindGameObjectWithTag("Minion");
    }

    void Update()
    {
        animator.SetBool("IsAttacking", false);


        
    }

    private IEnumerator MinionSpawners(float randomtime, GameObject Minion)
    {
        yield return new WaitForSeconds(randomtime);
        GameObject bulletClone = Instantiate(MinionPrefab, MinionSpawner.position, MinionSpawner.rotation);
        StartCoroutine(MinionSpawners(randomtime, Minion));
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
            animator.Play("Run");
            StartCoroutine(MinionSpawners(Random.Range(MinionSpawnTimeMin, MinionSpawnTimeMax), MinionPrefab));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("Attack(1)");
            animator.SetBool("IsAttacking", true);
        }
    }

}
