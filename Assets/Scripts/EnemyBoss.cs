using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    public int BossHealth = 40;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PistolBullet"))
        {
            BossHealth--;

            if (BossHealth < 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PistolShoot>().WhenEnemyIsKilled();

                Destroy(this.gameObject);
            }
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("EnemyCrab").GetComponent<EnemyCrab>().WhenEnemyHitsPlayer();
        }

    }
}
